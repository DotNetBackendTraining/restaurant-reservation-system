using RestaurantReservation.DTOs;

namespace RestaurantReservation.Interfaces.Services;

public interface IReservationService
{
    Task<IEnumerable<ReservationDto>> GetReservationsByCustomerAsync(int customerId);

    Task<ReservationDetailDto?> GetReservationDetailAsync(int reservationId);

    Task<IEnumerable<CustomerDto>> GetCustomersWithPartySizeGreaterThan(int partySize);
}