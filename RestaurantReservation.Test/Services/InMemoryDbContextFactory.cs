using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Presentation.Interfaces;

namespace RestaurantReservation.Test.Services;

public class InMemoryDbContextFactory : IDbContextFactory
{
    private readonly DbContextOptions _options;

    public InMemoryDbContextFactory(string databaseName)
    {
        _options = new DbContextOptionsBuilder()
            .UseInMemoryDatabase(databaseName)
            .Options;
    }

    public RestaurantReservationDbContext Create()
    {
        return new RestaurantReservationDbContext(_options);
    }

    public static RestaurantReservationDbContext CreateDbContext(string databaseName)
    {
        return new InMemoryDbContextFactory(databaseName).Create();
    }
}