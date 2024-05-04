using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.Domain.Interfaces.Repositories;

public interface IEmployeeRepository
{
    IAsyncEnumerable<Employee> GetAllManagersAsync();

    Task<EmployeeRestaurantDetail?> GetEmployeeRestaurantDetailAsync(int employeeId);

    /// <exception cref="InvalidOperationException">If no employee with the given ID was found</exception>
    Task<double> CalculateAverageOrderAmountAsync(int employeeId);

    /// <exception cref="InvalidOperationException">If no restaurant with the given ID was found</exception>
    Task<decimal> GetTotalRevenueByRestaurant(int restaurantId);
}