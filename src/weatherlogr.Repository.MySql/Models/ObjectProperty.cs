using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace weatherlogr.Repository.MySql.Models;

[PrimaryKey(nameof(ClassName), nameof(EntryName))]
public sealed class ObjectProperty
{
    [MaxLength(512)]
    public string ClassName { get; set; } = string.Empty;

    [MaxLength(60)]
    public string EntryName { get; set; } = string.Empty;

    public string? StringValue { get; set; }

    public int? IntValue { get; set; }

    public long? LongValue { get; set; }

    public decimal? DecimalValue { get; set; }

    public bool? BoolValue { get; set; }
}