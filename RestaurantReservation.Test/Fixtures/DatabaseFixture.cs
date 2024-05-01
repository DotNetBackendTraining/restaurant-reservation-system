using Microsoft.Data.Sqlite;
using RestaurantReservation.Presentation.Interfaces;
using RestaurantReservation.Test.Services;

namespace RestaurantReservation.Test.Fixtures;

/// <summary>
/// Use when you want to share a database instance across multiple tests
/// </summary>
public class DatabaseFixture : IDisposable
{
    private readonly SqliteConnection _connection;

    public IDbContextFactory ContextFactory { get; }

    public DatabaseFixture()
    {
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open(); // Open connection to keep the in-memory database alive

        ContextFactory = new SqliteDbContextFactory(_connection);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _connection.Close();
    }
}