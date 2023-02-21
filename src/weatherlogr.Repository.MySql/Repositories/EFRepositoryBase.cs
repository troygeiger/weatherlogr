using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using weatherlogr.Core.Contracts.Repositories.Storage;

namespace weatherlogr.Repository.MySql.Repositories;

public abstract class EFRepositoryBase<TDto, TEntity> : ICrudBase<TDto>
    where TDto : class
    where TEntity : class
{
    private readonly WeatherContext context;
    private readonly IMapper mapper;
    private readonly DbSet<TEntity> DbSet;

    public EFRepositoryBase(WeatherContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
        DbSet = context.Set<TEntity>();
    }

    public bool AutoSaveChanges { get; set; } = true;

    private TEntity GetEntity(TDto dto)
    {
        TEntity entity = mapper.Map<TEntity>(dto);

        var entry = context.Entry(entity);

        if (entry.State == EntityState.Detached)
        {
            context.Attach(entity);
        }

        return entity;
    }

    public TDto AddNewItem(TDto item)
    {
        TEntity entity = GetEntity(item);

        DbSet.Add(entity);

        if (AutoSaveChanges)
            SaveChanges();

        return mapper.Map<TDto>(entity);
    }

    public async Task<TDto> AddNewItemAsync(TDto item, CancellationToken cancellationToken = default)
    {
        TEntity entity = GetEntity(item);

        DbSet.Add(entity);

        if (AutoSaveChanges)
            await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<TDto>(entity);
    }

    public void DeleteItem(TDto item)
    {
        TEntity entity = GetEntity(item);

        DbSet.Remove(entity);

        if (AutoSaveChanges)
            SaveChanges();
    }

    public async Task DeleteItemAsync(TDto item, CancellationToken cancellationToken = default)
    {
        TEntity entity = GetEntity(item);

        DbSet.Remove(entity);

        if (AutoSaveChanges)
            await context.SaveChangesAsync(cancellationToken);
    }

    public IQueryable<TDto> QueryStorage()
    {
        return mapper.ProjectTo<TDto>(DbSet);
    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }

    public TDto UpdateItem(TDto item)
    {
        TEntity entity = GetEntity(item);

        DbSet.Update(entity);

        if (AutoSaveChanges)
            SaveChanges();

        return mapper.Map<TDto>(entity);
    }

    public async Task<TDto> UpdateItemAsync(TDto item, CancellationToken cancellationToken = default)
    {
        TEntity entity = GetEntity(item);

        DbSet.Update(entity);

        if (AutoSaveChanges)
            await context.SaveChangesAsync(cancellationToken);
            
        return mapper.Map<TDto>(entity);
    }

    public IEnumerable<TDto> GetAttached()
    {
        foreach (EntityEntry<TEntity> item in context.ChangeTracker.Entries<TEntity>())
        {
            yield return mapper.Map<TDto>(item.Entity);
        }
    }

    public void ClearAttached()
    {
        context.ChangeTracker.Clear();
    }
}