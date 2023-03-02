using Microsoft.Extensions.Hosting;

namespace weatherlogr.Core.Services.Hosted;

public sealed class ObservationCollectorService : IHostedService
{
    private readonly IServiceProvider serviceProvider;
    private readonly HostedServiceMessaging serviceMessaging;

    public ObservationCollectorService(IServiceProvider serviceProvider, HostedServiceMessaging serviceMessaging)
    {
        this.serviceMessaging = serviceMessaging;
        this.serviceProvider = serviceProvider;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}