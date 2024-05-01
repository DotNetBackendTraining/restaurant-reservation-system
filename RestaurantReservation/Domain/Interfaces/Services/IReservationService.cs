using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Domain.Interfaces.Services;

public interface IReservationService
{
    IAsyncEnumerable<Reservation> GetReservationsByCustomerAsync(int customerId);
}