namespace weatherlogr.WeatherGovRepository.Models;

internal sealed class ObservationStationFeatureCollection : GeoJsonFeatureCollection<ObservationStation>
{

    public PaginationEntry? Pagination { get; set; }
}

