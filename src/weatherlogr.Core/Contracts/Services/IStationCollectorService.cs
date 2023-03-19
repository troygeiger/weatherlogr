using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using weatherlogr.Core.DTO;

namespace weatherlogr.Core.Contracts.Services
{
    public interface IStationCollectorService
    {
        IQueryable<StationCollectorRow> AsQueryable();

        Task<StationCollectorRow[]> GetAll();

        Task<StationCollectorRow?> GetStationCollectorAsync(string stationIdentifier);
        
        Task<StationCollectorRow> AddNewStationAsync(StationCollectorRow item);

        Task<StationCollectorRow> UpdateStationAsync(StationCollectorRow item);

        Task DeleteStationCollectorAsync(StationCollectorRow item);

        Task<bool> DeleteStationCollectorAsync(string stationIdentifier);

    }
}