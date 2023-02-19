using weatherlogr.Core.Contracts.Repositories;
using Microsoft.Extensions.DependencyInjection;
using weatherlogr.Core;
using weatherlogr.Core.Contracts.Repositories.WeatherGov;
using weatherlogr.WeatherGovRepository.Repositories;

namespace weatherlogr.WeatherGovRepository;
public class Registration : IRepositoryRegistration
{
    public string RepositoryType { get => "WeatherGov"; }

    public void RegisterRepositoryServices(IServiceCollection services, ConfigurationOptions options)
    {
        services.AddSingleton<WeatherGovRestSharpFactory>();

        services.AddTransient<IObservationStationRepository, StationRepository>();
    }
}
