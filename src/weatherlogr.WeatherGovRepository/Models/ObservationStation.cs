using System.Text.Json.Serialization;

namespace weatherlogr.WeatherGovRepository.Models;

internal sealed class ObservationStation
{
    [JsonPropertyName("@id")]
    public string ID { get; set; } = string.Empty;

    [JsonPropertyName("@type")]
    public string Type { get; set; } = string.Empty;

    public string StationIdentifier { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string TimeZone { get; set; } = string.Empty;
}

