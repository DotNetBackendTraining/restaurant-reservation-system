using RestaurantReservation.App.DTOs;

namespace RestaurantReservation.App.Interfaces.Services;

public interface IReservationService
{
    Task<ReservationDto?> GetReservationAsync(int reservationId);

    Task<IEnumerable<ReservationDto>> GetReservationsByCustomerAsync(int customerId);

    Task<ReservationDetailDto?> GetReservationDetailAsync(int reservationId);
}