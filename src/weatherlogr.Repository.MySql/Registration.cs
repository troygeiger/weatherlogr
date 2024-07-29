using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using weatherlogr.Core;
using weatherlogr.Core.Contracts.Repositories;
using weatherlogr.Core.Contracts.Repositories.Storage;
using weatherlogr.Core.DTO;
using weatherlogr.Repository.MySql.Models;
using weatherlogr.Repository.MySql.Repositories;

namespace weatherlogr.Repository.MySql;

public sealed class Registration : IRepositoryRegistration
{
    public string RepositoryType => "MySql";

    public void RegisterAutoMapper(MapperConfigurationExpression mapConfig)
    {
        mapConfig.CreateMap<StationCollector, StationCollectorRow>().ReverseMap();
        mapConfig.CreateMap<Observation, ObservationRow>().ReverseMap();
        mapConfig.CreateMap<RadarSource, RadarSourceRow>().ReverseMap();
        mapConfig.CreateMap<RadarIndex, RadarIndexRow>().ReverseMap();
    }

    public void RegisterRepositoryServices(IServiceCollection services, ConfigurationOptions configOptions)
    {
        services.AddDbContext<WeatherContext>(dbOptions =>
        {
            dbOptions.UseMySql(configOptions.StorageConnectionString,
                               ServerVersion.AutoDetect(configOptions.StorageConnectionString));
        });

        services.AddScoped<IStationCollectorRepository, StationCollectorRepository>();
        services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
        services.AddScoped<IObservationRepository, ObservationRepository>();
        services.AddScoped<IRadarIndexRepository, RadarIndexRepository>();
        services.AddScoped<IRadarSourcesRepository, RadarSourcesRepository>();
    }
}