using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Presentation.Interfaces;

namespace RestaurantReservation.Test.Services;

public class SqliteDbContextFactory : IDbContextFactory, IDisposable
{
    private readonly SqliteConnection _connection;
    private readonly DbContextOptions _options;

    public SqliteDbContextFactory()
    {
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open(); // Open connection to keep the in-memory database alive

        _options = new DbContextOptionsBuilder()
            .UseSqlite(_connection)
            .Options;

        using var context = Create();
        context.Database.EnsureCreated();
    }

    public RestaurantReservationDbContext Create()
    {
        return new RestaurantReservationDbContext(_options);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _connection.Close();
    }
}