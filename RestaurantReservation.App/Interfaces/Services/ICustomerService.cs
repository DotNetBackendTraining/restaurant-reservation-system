using RestaurantReservation.App.Common;
using RestaurantReservation.App.DTOs;

namespace RestaurantReservation.App.Interfaces.Services;

public interface ICustomerService
{
    Task<Result<CustomerDto>> CreateAsync(CustomerDto dto);

    Task<Result> UpdateAsync(CustomerDto dto);

    Task<Result> DeleteAsync(CustomerDto dto);

    Task<Result<CustomerDto>> GetCustomerAsync(int customerId);

    Task<Result<IEnumerable<CustomerDto>>> GetCustomersWithPartySizeGreaterThanAsync(int partySize);
}