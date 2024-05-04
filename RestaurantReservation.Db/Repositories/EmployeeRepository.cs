using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Interfaces.Repositories;
using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.Db.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly RestaurantReservationDbContext _context;

    public EmployeeRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public IAsyncEnumerable<Employee> GetAllManagersAsync()
    {
        return _context.Employees
            .Where(e => e.Position == "Manager")
            .AsAsyncEnumerable();
    }

    public async Task<EmployeeRestaurantDetail?> GetEmployeeRestaurantDetailAsync(int employeeId)
    {
        return await _context.EmployeeRestaurantDetails.FindAsync(employeeId);
    }

    public async Task<double> CalculateAverageOrderAmountAsync(int employeeId)
    {
        return await _context.Employees
            .Where(e => e.EmployeeId == employeeId)
            .SelectMany(e => e.Orders)
            .AverageAsync(o => o.TotalAmount);
    }

    public async Task<decimal> GetTotalRevenueByRestaurant(int restaurantId)
    {
        return await _context.Restaurants
            .Where(r => r.RestaurantId == restaurantId)
            .Select(r => _context.GetTotalRevenueByRestaurant(r.RestaurantId))
            .FirstAsync();
    }
}