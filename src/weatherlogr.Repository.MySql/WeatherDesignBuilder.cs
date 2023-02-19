using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace weatherlogr.Repository.MySql;

public class WeatherDesignBuilder : Microsoft.EntityFrameworkCore.Design.IDesignTimeDbContextFactory<WeatherContext>
{
    public WeatherContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<WeatherContext> builder = new();
        builder.UseMySql(ServerVersion.Create(Version.Parse("10.3.34"), ServerType.MariaDb));
        return new WeatherContext(builder.Options);
    }
}