using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace weatherlogr.Core.DTO
{
    public sealed class ObservationRow
    {
        [Key]
        public long ID { get; set; }

        public DateTimeOffset EntryDate { get; set; }

        [MaxLength(10)]
        public string StationID { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? ObsDescription { get; set; }

        public decimal? Temperature { get; set; }

        [MaxLength(15)]
        public string? TemperatureUOM { get; set; }

        public decimal? DewPoint { get; set; }

        [MaxLength(15)]
        public string? DewPointUOM { get; set; }

        public decimal? Humidity { get; set; }

        [MaxLength(15)]
        public string? HumidityUOM { get; set; }

        public decimal? WindSpeed { get; set; }

        [MaxLength(15)]
        public string? WindSpeedUOM { get; set; }

        public decimal? WindGust { get; set; }

        [MaxLength(15)]
        public string? WindGustUOM { get; set; }

        public decimal? BarometricPressure { get; set; }

        [MaxLength(15)]
        public string? BarometricPressureUOM { get; set; }

        public decimal? WindChill { get; set; }

        [MaxLength(15)]
        public string? WindChillUOM { get; set; }

        public decimal? HeatIndex { get; set; }

        [MaxLength(15)]
        public string? HeatIndexUOM { get; set; }

        public decimal? Visibility { get; set; }

        [MaxLength(15)]
        public string? VisibilityUOM { get; set; }

        public decimal? GetTemperatureInFahrenheit() => Temperature is null ? null : (Temperature * 9/5) + 32;
    }
}