using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using RestaurantReservation.Db;

namespace RestaurantReservation.Tools;

public class RestaurantReservationDbContextFactory : IDesignTimeDbContextFactory<RestaurantReservationDbContext>
{
    public RestaurantReservationDbContext CreateDbContext(string[] args)
    {
        var configurationRoot = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        var connectionString = configurationRoot.GetConnectionString("SQLServerConnection");

        var options = new DbContextOptionsBuilder()
            .UseSqlServer(connectionString)
            .Options;

        return new RestaurantReservationDbContext(options);
    }
}