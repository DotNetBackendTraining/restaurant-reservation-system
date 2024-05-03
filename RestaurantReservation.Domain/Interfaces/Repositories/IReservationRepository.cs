using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.Domain.Interfaces.Repositories;

public interface IReservationRepository
{
    IAsyncEnumerable<Reservation> GetAllReservationsByCustomerAsync(int customerId);
    Task<ReservationDetail?> GetReservationDetailAsync(int reservationId);
}