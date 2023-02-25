using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weatherlogr.Core.DTO;

namespace weatherlogr.Core.Contracts.Services
{
    public interface IObservationStationService
    {
        IQueryable<ObservationStationRow> GetStations(string state);

        Task<IQueryable<ObservationStationRow>> GetStationsAsync(string state);

    }
}
