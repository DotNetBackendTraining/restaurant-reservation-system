using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;

namespace RestaurantReservation.App.Configuration.Db;

public class DefaultDbContextFactory : IDbContextFactory
{
    private readonly DbContextOptions _options;

    public DefaultDbContextFactory(DatabaseSettings settings)
    {
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