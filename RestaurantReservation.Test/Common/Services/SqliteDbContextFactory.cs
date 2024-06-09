using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;

namespace RestaurantReservation.Test.Common.Services;

/// <summary>
/// Does not control the connection. Open it and close it separately.
/// </summary>
public class SqliteDbContextFactory : IDbContextFactory<RestaurantReservationDbContext>
{
    private readonly DbContextOptions<RestaurantReservationDbContext> _options;

    public SqliteDbContextFactory(SqliteConnection connection)
    {
        _options = new DbContextOptionsBuilder<RestaurantReservationDbContext>()
            .UseSqlite(connection)
            .Options;

        using var context = CreateDbContext();
        context.Database.EnsureCreated();
    }

    public RestaurantReservationDbContext CreateDbContext()
    {
        return new RestaurantReservationDbContext(_options);
    }
}