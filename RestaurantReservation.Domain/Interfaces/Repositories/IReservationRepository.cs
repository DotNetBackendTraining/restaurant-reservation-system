using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.Domain.Interfaces.Repositories;

public interface IReservationRepository
{
    Task<Reservation?> GetReservationAsync(int reservationId);

    IAsyncEnumerable<Reservation> GetAllReservationsByCustomerAsync(int customerId);

    Task<ReservationDetail?> GetReservationDetailAsync(int reservationId);
}