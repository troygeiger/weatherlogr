using Microsoft.Extensions.DependencyInjection;

namespace weatherlogr.Core.Contracts.Repositories;

public interface IRepositoryRegistration
{
    string RepositoryType { get; }

    void RegisterRepositoryServices(IServiceCollection services, ConfigurationOptions configOptions);
}