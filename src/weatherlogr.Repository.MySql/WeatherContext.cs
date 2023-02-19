using System.Dynamic;
using Microsoft.EntityFrameworkCore;
using weatherlogr.Repository.MySql;

namespace weatherlogr.Repository.MySql;

public class WeatherContext : DbContext
{
    public WeatherContext(DbContextOptions options) : base(options)
    {
        Observations = Set<Observation>();
        UnitValues = Set<UnitValue>();
        RadarIndices = Set<RadarIndex>();
    }

    public DbSet<Observation> Observations { get; set; }

    public DbSet<UnitValue> UnitValues { get; set; }

    public DbSet<RadarIndex> RadarIndices { get; set; }
}
