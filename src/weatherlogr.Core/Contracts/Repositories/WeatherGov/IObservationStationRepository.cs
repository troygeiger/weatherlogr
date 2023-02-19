using weatherlogr.Core.DTO;

namespace weatherlogr.Core.Contracts.Repositories.WeatherGov;

public interface IObservationStationRepository
{
    IQueryable<StationLookupRow> GetStations(string state);
}