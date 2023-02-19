using System;
using System.ComponentModel.DataAnnotations;
using System.Formats.Asn1;

namespace weatherlogr.Repository.MySql;

public sealed class Observation
{
    [Key]
    public long ID { get; set; }

    public DateTimeOffset EntryDate { get; set; }

    [MaxLength(10)]
    public string StationID { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? ObsDescription { get; set; }

    public UnitValue? Temperature { get; set; }

    public UnitValue? DewPoint { get; set; }

    public UnitValue? Humidity { get; set; }

    public UnitValue? WindSpeed { get; set; }

    public UnitValue? WindGust { get; set; }

    public UnitValue? BarometricPressure { get; set; }

    public UnitValue? WindChill { get; set; }

    public UnitValue? HeatIndex { get; set; }

    public UnitValue? Visibility { get; set; }
}
