using RestaurantReservation.Db;

namespace RestaurantReservation.Configuration.Db;

public interface IDbContextFactory
{
    RestaurantReservationDbContext Create();
}