using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using weatherlogr.Repository.MySql.Models;

namespace weatherlogr.Repository.MySql;

[Index(nameof(RadarIndex.RadarDate))]
public sealed class RadarIndex
{
    [Key]
    public Guid ID { get; set; }

    public int RadarSourceID { get; set; }

    public RadarSource RadarSource { get; set; } = new();

    public DateTimeOffset RadarDate { get; set; }
}
