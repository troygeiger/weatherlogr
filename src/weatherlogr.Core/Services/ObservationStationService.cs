using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weatherlogr.Core.Contracts.Repositories.WeatherGov;
using weatherlogr.Core.Contracts.Services;
using weatherlogr.Core.DTO;

namespace weatherlogr.Core.Services
{
    public class ObservationStationService : IObservationStationService
    {
        private readonly IObservationStationRepository repository;

        public ObservationStationService(IObservationStationRepository repository)
        {
            this.repository = repository;
        }

        public IQueryable<ObservationStationRow> GetStations(string state)
        {
            return repository.GetStations(state);
        }

        public Task<IQueryable<ObservationStationRow>> GetStationsAsync(string state)
        => Task.Run(() => GetStations(state));
    }
}
