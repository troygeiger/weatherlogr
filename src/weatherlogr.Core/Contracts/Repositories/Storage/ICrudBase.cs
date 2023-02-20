namespace weatherlogr.Core.Contracts.Repositories.Storage;

public interface ICrudBase<TDto>
where TDto : class
{
    bool AutoSaveChanges { get; set; }

    IQueryable<TDto> QueryStorage();

    TDto AddNewItem(TDto item);

    Task<TDto> AddNewItemAsync(TDto item);

    TDto UpdateItem(TDto item);

    Task<TDto> UpdateItemAsync(TDto item);

    void DeleteItem(TDto item);

    Task DeleteItemAsync(TDto item);

    void SaveChanges();

    Task SaveChangesAsync();
}