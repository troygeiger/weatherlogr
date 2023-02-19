namespace weatherlogr.WeatherGovRepository.Models;

internal class GeoJsonFeatureCollection<T>
{
    public GeoJsonFeatureCollection()
    {
        Type = string.Empty;
        Features = Array.Empty<GeoJsonFeature<T>>();
    }

    public string Type { get; set; }

    public IEnumerable<GeoJsonFeature<T>> Features { get; set; }
}