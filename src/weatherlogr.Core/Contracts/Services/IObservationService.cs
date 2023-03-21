using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using weatherlogr.Core.DTO;

namespace weatherlogr.Core.Contracts.Services
{
    public interface IObservationService
    {
        bool AutoSaveChanges { get; set; }

        Task<IQueryable<ObservationRow>> QueryObservations();

        Task<ObservationRow> AddObservation(ObservationRow observation, CancellationToken cancellationToken = default);

        Task<bool> AddObservationRangeAsync(IEnumerable<ObservationRow> observations, CancellationToken cancellationToken = default);

        Task<IEnumerable<ObservationRow>> GetStationObservations(string stationIdentifier, CancellationToken cancellationToken = default);

        Task SaveChangesAsync();

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}