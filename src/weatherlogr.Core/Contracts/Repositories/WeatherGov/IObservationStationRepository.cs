using weatherlogr.Core.DTO;

namespace weatherlogr.Core.Contracts.Repositories.WeatherGov;

public interface IObservationStationRepository
{
    IQueryable<ObservationStationRow> GetStations(string state);
}