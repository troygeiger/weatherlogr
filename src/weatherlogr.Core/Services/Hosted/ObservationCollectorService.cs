using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NCrontab;
using weatherlogr.Core.Contracts.Repositories.WeatherGov;
using weatherlogr.Core.Contracts.Services;
using weatherlogr.Core.DTO;

namespace weatherlogr.Core.Services.Hosted;

public sealed class ObservationCollectorService : IHostedService
{
    private readonly IServiceProvider serviceProvider;
    private readonly HostedServiceMessaging serviceMessaging;
    private readonly ILogger<ObservationCollectorService> logger;
    private SystemConfigurationEntry sysConfig;
    private CancellationTokenSource tokenSource;
    private CrontabSchedule? schedule;

    public ObservationCollectorService(IServiceProvider serviceProvider,
                                       HostedServiceMessaging serviceMessaging,
                                       ILogger<ObservationCollectorService> logger)
    {
        this.serviceMessaging = serviceMessaging;
        this.logger = logger;
        this.serviceProvider = serviceProvider;
        sysConfig = new();
        tokenSource = new CancellationTokenSource();
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        sysConfig = GetSystemConfiguration();
        schedule = CrontabSchedule.TryParse(sysConfig.PickupSchedule);
        if (schedule is null)
            return Task.CompletedTask;
        ThreadPool.QueueUserWorkItem<CancellationToken>(ScheduleThread, tokenSource.Token, false);
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        tokenSource.Cancel();
        return Task.CompletedTask;
    }

    private SystemConfigurationEntry GetSystemConfiguration()
    {
        using var scope = serviceProvider.CreateScope();

        var service = scope.ServiceProvider.GetRequiredService<ISystemConfigurationService>();
        return service.Configuration;
    }

    private bool LoadConfigAndSchedule()
    {
        sysConfig = GetSystemConfiguration();
        schedule = CrontabSchedule.TryParse(sysConfig.PickupSchedule);

        return schedule is null ? false : true;
    }

    private RunStates CheckConfigState()
    {
        if (!serviceMessaging.ShouldReloadSystemConfiguration)
            return RunStates.Ok;
        serviceMessaging.ShouldReloadSystemConfiguration = false;
        var origSched = schedule;
        if (!LoadConfigAndSchedule())
        {
            logger.LogWarning("Schedule could not be parsed. Observation collection will stop until corrected.");
            schedule = origSched;
            return RunStates.NoRun;
        }
        return RunStates.Reschedule;
    }

    private async void ScheduleThread(CancellationToken cancellationToken)
    {
        DateTime nextPickup = schedule!.GetNextOccurrence(DateTime.Now);
        while (!cancellationToken.IsCancellationRequested)
        {
            Thread.Sleep(1000);
            switch (CheckConfigState())
            {
                case RunStates.NoRun:
                    continue;
                case RunStates.Reschedule:
                    nextPickup = schedule!.GetNextOccurrence(DateTime.Now);
                    break;
            }
            if (DateTime.Now >= nextPickup)
            {
                try
                {
                    await CollectObservationsAsync(cancellationToken);
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "Error occurred while executing GetObservations.");
                }
                nextPickup = schedule.GetNextOccurrence(DateTime.Now);
            }

        }
    }

    private async Task CollectObservationsAsync(CancellationToken cancellationToken)
    {
        using var scope = serviceProvider.CreateScope();


        var collectors = scope.ServiceProvider.GetRequiredService<IStationCollectorService>();
        var observationService = scope.ServiceProvider.GetRequiredService<IObservationService>();
        var stationObsRepository = scope.ServiceProvider.GetRequiredService<IStationObservationsRepository>();

        foreach (var collector in await collectors.GetAll())
        {
            if (cancellationToken.IsCancellationRequested) break;
            DateTimeOffset start = collector.LastCollectionEnd ?? DateTimeOffset.UtcNow.AddDays(-10);

            // It seems that you have to subtract several hours from the
            // start window in order to have weather.gov's api to
            // return a dataset with the needed date window. -8 hours seems to
            // work and then I just get a subset of the result set greater than
            // the last.
            var results = (await stationObsRepository.GetStationObservationsAsync(collector.StationIdentifier, start.AddHours(-8), DateTimeOffset.UtcNow))
                .Where(r => r.EntryDate > start)
                .ToArray();
            
            if (results.Any() == false) continue;

            bool success = await observationService.AddObservationRangeAsync(results, cancellationToken);

            if (!success)
            {
                return;
            }

            collector.LastCollectionEnd = results.Max(o => o.EntryDate);
            await collectors.UpdateStationAsync(collector);
        }
    }

    internal enum RunStates
    {
        Ok,
        Reschedule,
        NoRun
    }
}