using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Application.Interfaces.Services;

public interface IReservationService
{
    IAsyncEnumerable<Reservation> GetReservationsByCustomerAsync(int customerId);
}