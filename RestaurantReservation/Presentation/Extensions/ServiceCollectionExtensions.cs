using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Db;
using RestaurantReservation.Presentation.Interfaces;
using RestaurantReservation.Presentation.Services;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace RestaurantReservation.Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    public static void InjectDatabase(this IServiceCollection collection, IConfiguration configuration)
    {
        collection.AddScoped<RestaurantReservationDbContext>(_ =>
        {
            var connectionString = configuration.GetConnectionString("SqlServerConnection");
            var logLevel = Enum.Parse<LogLevel>(configuration.GetSection("Logging")["LogLevel"] ?? "");
            var sensitiveLog = bool.Parse(configuration.GetSection("Logging")["EnableSensitiveDataLogging"] ?? "");

            var options = new DbContextOptionsBuilder()
                .UseSqlServer(connectionString)
                .LogTo(Console.WriteLine, logLevel)
                .EnableSensitiveDataLogging(sensitiveLog)
                .Options;

            return new RestaurantReservationDbContext(options);
        });
    }

    public static void InjectPresentation(this IServiceCollection collection)
    {
        collection.AddScoped<IExecutor, DynamicExecutor<IGenericController>>();
    }
}