using RestaurantReservation.Db;

namespace RestaurantReservation.App.Configuration.Db;

public interface IDbContextFactory
{
    RestaurantReservationDbContext Create();
}