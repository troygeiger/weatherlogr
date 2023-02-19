using System.ComponentModel.DataAnnotations;

namespace weatherlogr.Repository.MySql;

public sealed class UnitValue
{
    [Key]
    public long Id { get; set; }

    [MaxLength(30)]
    public string? UnitCode { get; set; }

    public decimal? Value { get; set; }
}
