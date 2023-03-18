using weatherlogr.Core.DTO;

namespace weatherlogr.Core.Contracts.Repositories.Storage;

public interface IConfigurationRepository
{
    T GetValue<T>() where T : class;

    void SaveValue<T>(T value) where T : class;
}