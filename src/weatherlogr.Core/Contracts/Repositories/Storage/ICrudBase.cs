namespace weatherlogr.Core.Contracts.Repositories.Storage;

public interface ICrudBase<TDto>
where TDto : class
{
    bool AutoSaveChanges { get; set; }

    IQueryable<TDto> QueryStorage();

    TDto AddNewItem(TDto item);

    Task<TDto> AddNewItemAsync(TDto item, CancellationToken cancellationToken = default);

    TDto UpdateItem(TDto item);

    Task<TDto> UpdateItemAsync(TDto item, CancellationToken cancellationToken = default);

    void DeleteItem(TDto item);

    Task DeleteItemAsync(TDto item, CancellationToken cancellationToken = default);

    void SaveChanges();

    Task SaveChangesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// If implemented, clear any tracked items contained in the repository.
    /// </summary>
    IEnumerable<TDto> GetAttached();

    /// <summary>
    /// If implemented, clear any tracked items contained in the repository.
    /// </summary>
    void ClearAttached();
}