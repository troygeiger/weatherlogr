using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace weatherlogr.WeatherGovRepository.Models
{
    internal class Observation
    {
        [JsonPropertyName("@id")]
        public string? ID { get; set; }

        [JsonPropertyName("@type")]
        public string? Type { get; set; }

        public UnitValueEntry? Elevation { get; set; }
        
        public string Station { get; set; } = string.Empty;
        
        public DateTimeOffset timestamp { get; set; }
        
        public string RawMessage { get; set; } = string.Empty;
        
        public string TextDescription { get; set; } = string.Empty;
        
        public string Icon { get; set; } = string.Empty;
        
        public UnitValueEntry? Temperature { get; set; }
        
        public UnitValueEntry? Dewpoint { get; set; }
        
        public UnitValueEntry? WindDirection { get; set; }
        
        public UnitValueEntry? WindSpeed { get; set; }
        
        public UnitValueEntry? WindGust { get; set; }
        
        public UnitValueEntry? BarometricPressure { get; set; }
        
        public UnitValueEntry? SeaLevelPressure { get; set; }
        
        public UnitValueEntry? Visibility { get; set; }
        
        public UnitValueEntry? MaxTemperatureLast24Hours { get; set; }
        
        public UnitValueEntry? MinTemperatureLast24Hours { get; set; }
        
        public UnitValueEntry? PrecipitationLastHour { get; set; }
        
        public UnitValueEntry? PrecipitationLast3Hours { get; set; }
        
        public UnitValueEntry? PrecipitationLast6Hours { get; set; }
        
        public UnitValueEntry? RelativeHumidity { get; set; }
        
        public UnitValueEntry? WindChill { get; set; }
        
        public UnitValueEntry? HeatIndex { get; set; }
        
    }
}