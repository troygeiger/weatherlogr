using System.Net.Http.Headers;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using weatherlogr.Core.Contracts.Repositories;

namespace weatherlogr.Core;

public static class CoreServiceCollectionExtensions
{
    public static IServiceCollection AddWeatherLogR(this IServiceCollection services, ConfigurationOptions options)
    {
        services.AddSingleton<ConfigurationOptions>(options);

        RegisterRepositories(services, options);

        

        return services;
    }

    public static IServiceCollection AddWeatherLogR(this IServiceCollection services, Action<ConfigurationOptions> optionsAction)
    {
        ConfigurationOptions options = new();
        optionsAction.Invoke(options);
        return AddWeatherLogR(services, options);
    }

    private static void RegisterRepositories(IServiceCollection services, ConfigurationOptions options)
    {
        string[] dlls = Directory.GetFiles(AppContext.BaseDirectory, "weatherlogr*.dll");

        Type iRegistration = typeof(IRepositoryRegistration);

        var registrations = dlls.Select(d => Assembly.LoadFrom(d))
            .SelectMany(a => a.GetTypes())
            .Where(t => iRegistration.IsAssignableFrom(t) && t != iRegistration)
            .Select(t => t.GetConstructors().FirstOrDefault(c => c.GetParameters().Any() == false))
            .Where(c => c is not null)
            .Select(c => c!.Invoke(null) as IRepositoryRegistration)
            .Where(i => i is not null)
            .ToArray();

        var weatherGov = registrations.FirstOrDefault(r => r!.RepositoryType == "WeatherGov");

        if (weatherGov is null)
            throw new DllNotFoundException("weatherlogr.WeatherGovRepository.dll not found");

        weatherGov.RegisterRepositoryServices(services, options);

        foreach (var registration in registrations
            .Where(r => string.Equals(options.StorageRepositoryType, r!.RepositoryType, StringComparison.OrdinalIgnoreCase)))
        {
            registration!.RegisterRepositoryServices(services, options);
        }

    }
}