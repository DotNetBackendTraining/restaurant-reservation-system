using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Interfaces.Repositories;
using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.Db.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly RestaurantReservationDbContext _context;

    public CustomerRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<Customer?> GetCustomer(int customerId)
    {
        return await _context.Customers.FindAsync(customerId);
    }

    public IAsyncEnumerable<Customer> GetCustomersWithPartySizeGreaterThan(int partySize)
    {
        return _context.Customers
            .FromSqlInterpolated($"EXEC FindCustomersWithPartySizeGreaterThan @PartySize = {partySize}")
            .AsAsyncEnumerable();
    }
}