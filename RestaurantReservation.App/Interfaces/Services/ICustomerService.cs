using RestaurantReservation.App.DTOs;

namespace RestaurantReservation.App.Interfaces.Services;

public interface ICustomerService
{
    Task<CustomerDto?> GetCustomerAsync(int customerId);

    Task<IEnumerable<CustomerDto>> GetCustomersWithPartySizeGreaterThanAsync(int partySize);
}