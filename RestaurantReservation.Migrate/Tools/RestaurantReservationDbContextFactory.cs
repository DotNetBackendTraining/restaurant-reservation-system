using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using RestaurantReservation.Db;

namespace RestaurantReservation.Migrate.Tools;

public class RestaurantReservationDbContextFactory : IDesignTimeDbContextFactory<RestaurantReservationDbContext>
{
    public RestaurantReservationDbContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .Build();

        var options = new DbContextOptionsBuilder()
            .UseSqlServer(config.GetSection("DatabaseSettings")["ConnectionString"])
            .Options;

        return new RestaurantReservationDbContext(options);
    }
}