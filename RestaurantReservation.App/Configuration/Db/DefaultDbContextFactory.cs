using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestaurantReservation.Db;

namespace RestaurantReservation.Configuration.Db;

public class DefaultDbContextFactory : IDbContextFactory
{
    private readonly DbContextOptions _options;

    public DefaultDbContextFactory(IConfiguration databaseConfiguration)
    {
        var connectionString = databaseConfiguration.GetConnectionString("SqlServerConnection");
        var logLevel = Enum.Parse<LogLevel>(databaseConfiguration.GetSection("Logging")["LogLevel"] ?? "");
        var sensitiveLog = bool.Parse(databaseConfiguration.GetSection("Logging")["EnableSensitiveDataLogging"] ?? "");

        _options = new DbContextOptionsBuilder()
            .UseSqlServer(connectionString)
            .LogTo(Console.WriteLine, logLevel)
            .EnableSensitiveDataLogging(sensitiveLog)
            .Options;
    }

    public RestaurantReservationDbContext Create()
    {
        return new RestaurantReservationDbContext(_options);
    }
}