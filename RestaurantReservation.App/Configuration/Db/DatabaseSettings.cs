using Microsoft.Extensions.Logging;

namespace RestaurantReservation.App.Configuration.Db;

public class DatabaseSettings
{
    public string ConnectionString { get; set; } = string.Empty;
    public LogLevel LogLevel { get; set; }
    public bool EnableSensitiveDataLogging { get; set; }
}