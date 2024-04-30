using RestaurantReservation.Db;

namespace RestaurantReservation.Presentation.Interfaces;

public interface IDbContextFactory
{
    RestaurantReservationDbContext Create();
}