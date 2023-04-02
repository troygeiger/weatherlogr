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

        Task<ObservationRow> AddObservation(ObservationRow observation,
                                            CancellationToken cancellationToken = default);

        Task<bool> AddObservationRangeAsync(IEnumerable<ObservationRow> observations,
                                            CancellationToken cancellationToken = default);

        Task<IEnumerable<ObservationRow>> GetAllStationObservations(string stationIdentifier,
                                                                    CancellationToken cancellationToken = default);
        
        Task<IEnumerable<ObservationRow>> GetStationObservations(string stationIdentifier,
                                                                 DateTime start,
                                                                 DateTime end);
        
        Task<IEnumerable<ObservationRow>> GetStationObservations(string stationIdentifier,
                                                                 DateTime start,
                                                                 DateTime end,
                                                                 CancellationToken cancellationToken = default);

        IQueryable<ObservationRow> QueryObservations();

        Task SaveChangesAsync();

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}