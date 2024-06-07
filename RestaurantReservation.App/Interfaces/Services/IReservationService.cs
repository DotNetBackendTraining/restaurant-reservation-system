using RestaurantReservation.App.DTOs;

namespace RestaurantReservation.App.Interfaces.Services;

public interface IReservationService
{
    Task<IEnumerable<ReservationDto>> GetReservationsByCustomerAsync(int customerId);

    Task<ReservationDetailDto?> GetReservationDetailAsync(int reservationId);

    Task<IEnumerable<CustomerDto>> GetCustomersWithPartySizeGreaterThan(int partySize);
}