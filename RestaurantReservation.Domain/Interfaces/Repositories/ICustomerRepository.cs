using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.Domain.Interfaces.Repositories;

public interface ICustomerRepository
{
    Task<Customer?> GetCustomer(int customerId);

    IAsyncEnumerable<Customer> GetCustomersWithPartySizeGreaterThan(int partySize);
}