using weatherlogr.Core.DTO;

namespace weatherlogr.Core.Contracts.Repositories.WeatherGov;

public interface IStationLookupRepository
{
    IQueryable<StationLookupRow> GetStations(string state);
}