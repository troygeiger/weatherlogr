using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using weatherlogr.Core.Contracts.Repositories.Storage;
using weatherlogr.Core.Contracts.Services;
using weatherlogr.Core.DTO;
using weatherlogr.Core.Extensions;

namespace weatherlogr.Core.Services
{
    public class StationCollectorService : IStationCollectorService
    {
        private readonly IStationCollectorRepository repository;

        public StationCollectorService(IStationCollectorRepository repository)
        {
            this.repository = repository;
        }

        public async Task<StationCollectorRow> AddNewStationAsync(StationCollectorRow item)
        {
            return await repository.AddNewItemAsync(item);
        }

        public IQueryable<StationCollectorRow> AsQueryable()
        {
            return repository.QueryStorage();
        }

        public async Task<StationCollectorRow[]> GetAll()
        {
            return await repository.QueryStorage().ToArrayAsync();
        }

        public async Task DeleteStationCollectorAsync(StationCollectorRow item)
        {
            await repository.DeleteItemAsync(item);
        }

        public async Task<StationCollectorRow?> GetStationCollectorAsync(string stationIdentifier)
        {
            return await repository.QueryStorage().FirstOrDefaultAsync(s => s.StationIdentifier == stationIdentifier);
        }

        public async Task<StationCollectorRow> UpdateStationAsync(StationCollectorRow item)
        {
            return await repository.UpdateItemAsync(item);
        }

        public async Task<bool> DeleteStationCollectorAsync(string stationIdentifier)
        {
            var station = await GetStationCollectorAsync(stationIdentifier);
            if (station is null)
                return false;
            await repository.DeleteItemAsync(station);
            return true;
        }
    }
}