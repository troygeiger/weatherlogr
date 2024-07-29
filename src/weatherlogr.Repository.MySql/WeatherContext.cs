using System.Dynamic;
using Microsoft.EntityFrameworkCore;
using weatherlogr.Repository.MySql;
using weatherlogr.Repository.MySql.Models;

namespace weatherlogr.Repository.MySql;

public class WeatherContext : DbContext
{
    public WeatherContext(DbContextOptions options) : base(options)
    {
        StationCollectors = Set<StationCollector>();
        Observations = Set<Observation>();
        RadarSources = Set<RadarSource>();
        RadarIndices = Set<RadarIndex>();
        ObjectProperties = Set<ObjectProperty>();
    }

    public DbSet<StationCollector> StationCollectors { get; set; }

    public DbSet<Observation> Observations { get; set; }

    public DbSet<RadarSource> RadarSources { get; set; }

    public DbSet<RadarIndex> RadarIndices { get; set; }

    public DbSet<ObjectProperty> ObjectProperties { get; set; }
}
