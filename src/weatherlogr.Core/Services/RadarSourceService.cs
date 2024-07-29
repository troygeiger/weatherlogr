using weatherlogr.Core.Contracts.Repositories.Storage;
using weatherlogr.Core.Contracts.Services;
using weatherlogr.Core.DTO;
using weatherlogr.Core.Extensions;

namespace Namespace;
public sealed class RadarSourceService : IRadarSourcesService
{
    private readonly IRadarSourcesRepository sourcesRepository;

    public RadarSourceService(IRadarSourcesRepository sourcesRepository)
    {
        this.sourcesRepository = sourcesRepository;
    }

    public async Task<RadarSourceRow> AddNewAsync(RadarSourceRow sourceRow)
    {
        if (sourceRow is null)
        {
            throw new ArgumentNullException(nameof(sourceRow));
        }
        return await sourcesRepository.AddNewItemAsync(sourceRow);
    }

    public async Task DeleteAsync(RadarSourceRow sourceRow)
    {
        await sourcesRepository.DeleteItemAsync(sourceRow);
    }

    public async Task<RadarSourceRow[]> GetAllAsync()
    {
        return await QuerySources().ToArrayAsync();
    }

    public async Task<RadarSourceRow?> GetByID(int id)
    {
        return await QuerySources().FirstOrDefaultAsync(x => x.ID == id);
    }

    public IQueryable<RadarSourceRow> QuerySources() => sourcesRepository.AsQueryable();

    public Task<RadarSourceRow> UpdateAsync(RadarSourceRow sourceRow)
    {
        return sourcesRepository.UpdateItemAsync(sourceRow);
    }
}
