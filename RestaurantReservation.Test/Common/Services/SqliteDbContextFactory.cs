using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;

namespace RestaurantReservation.Test.Common.Services;

/// <summary>
/// Does not control the connection. Open it and close it separately.
/// </summary>
public class SqliteDbContextFactory : IDbContextFactory
{
    private readonly DbContextOptions _options;

    public SqliteDbContextFactory(SqliteConnection connection)
    {
        _options = new DbContextOptionsBuilder()
            .UseSqlite(connection)
            .Options;

        using var context = Create();
        context.Database.EnsureCreated();
    }

    public RestaurantReservationDbContext Create()
    {
        return new RestaurantReservationDbContext(_options);
    }
}