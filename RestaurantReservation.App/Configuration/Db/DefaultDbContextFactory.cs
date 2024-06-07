using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RestaurantReservation.Db;

namespace RestaurantReservation.App.Configuration.Db;

public class DefaultDbContextFactory : IDbContextFactory
{
    private readonly DbContextOptions _options;

    public DefaultDbContextFactory(IOptions<DatabaseSettings> options)
    {
        var settings = options.Value;
        _options = new DbContextOptionsBuilder()
            .UseSqlServer(settings.ConnectionString)
            .LogTo(Console.WriteLine, settings.LogLevel)
            .EnableSensitiveDataLogging(settings.EnableSensitiveDataLogging)
            .Options;
    }

    public RestaurantReservationDbContext Create()
    {
        return new RestaurantReservationDbContext(_options);
    }
}