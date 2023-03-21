using System;
using System.ComponentModel.DataAnnotations;
using System.Formats.Asn1;
using weatherlogr.Repository.MySql.Models;

namespace weatherlogr.Repository.MySql;

public sealed class Observation
{
    public Observation()
    {
        StationID = string.Empty;
    }

    [Key]
    public long ID { get; set; }

    public DateTimeOffset EntryDate { get; set; }

    public StationCollector? Station { get; set; }

    [MaxLength(10)]
    public string StationID { get; set; }

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
}
