using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using weatherlogr.Core;
using weatherlogr.Core.Contracts.Repositories;

namespace weatherlogr.Repository.MySql;

public sealed class Registration : IRepositoryRegistration
{
    public string RepositoryType => "MySql";

    public void RegisterRepositoryServices(IServiceCollection services, ConfigurationOptions configOptions)
    {
        services.AddDbContext<WeatherContext>(dbOptions =>
        {
            dbOptions.UseMySql(configOptions.StorageConnectionString,
                               ServerVersion.AutoDetect(configOptions.StorageConnectionString));
        });
    }
}