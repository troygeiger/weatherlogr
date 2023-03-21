using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using weatherlogr.Core.DTO;

namespace weatherlogr.Core.Contracts.Repositories.WeatherGov
{
    public interface IStationObservationsRepository
    {
        Task<IEnumerable<ObservationRow>> GetStationObservationsAsync(string stationIdentifier,
                                                                      DateTimeOffset startDate,
                                                                      DateTimeOffset endDate,
                                                                      CancellationToken cancellationToken = default);
    }
}