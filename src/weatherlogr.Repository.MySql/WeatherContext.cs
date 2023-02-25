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
        RadarIndices = Set<RadarIndex>();
    }

    public DbSet<StationCollector> StationCollectors{get;set;}

    public DbSet<Observation> Observations { get; set; }

    public DbSet<RadarIndex> RadarIndices { get; set; }
}
