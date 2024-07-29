using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using weatherlogr.Core.DTO;

namespace weatherlogr.Core.Contracts.Services;

public interface IRadarSourcesService
{
    IQueryable<RadarSourceRow> QuerySources();

    Task<RadarSourceRow> AddNewAsync(RadarSourceRow sourceRow);

    Task<RadarSourceRow> UpdateAsync(RadarSourceRow sourceRow);

    Task DeleteAsync(RadarSourceRow sourceRow);

    Task<RadarSourceRow[]> GetAllAsync();

    Task<RadarSourceRow?> GetByID(int id);
}
