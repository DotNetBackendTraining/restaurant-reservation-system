using RestaurantReservation.Application.DTOs;

namespace RestaurantReservation.Application.Interfaces.Services;

public interface IReservationService
{
    IAsyncEnumerable<ReservationDto> GetReservationsByCustomerAsync(int customerId);
}