using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace weatherlogr.Repository.MySql;

public sealed class RadarIndex
{
    [Key]
    public Guid ID { get; set; }

    [MaxLength(10)]
    public string Type { get; set; } = string.Empty;

    public DateTimeOffset RadarDate { get; set; }
}
