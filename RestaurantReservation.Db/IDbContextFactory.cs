namespace RestaurantReservation.Db;

public interface IDbContextFactory
{
    RestaurantReservationDbContext Create();
}