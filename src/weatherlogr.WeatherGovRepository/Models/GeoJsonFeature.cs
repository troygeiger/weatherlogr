namespace weatherlogr.WeatherGovRepository.Models;

internal class GeoJsonFeature<T>
{
    public string? ID { get; set; }

    public string? Type { get; set; }

    public T? Properties { get; set; }
}

