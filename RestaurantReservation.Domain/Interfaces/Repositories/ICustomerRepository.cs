using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.Domain.Interfaces.Repositories;

public interface ICustomerRepository
{
    Task<Customer?> GetCustomer(int customerId);

    Task<Customer?> GetCustomerByEmailAsync(string email);

    IAsyncEnumerable<Customer> GetCustomersWithPartySizeGreaterThan(int partySize);
}