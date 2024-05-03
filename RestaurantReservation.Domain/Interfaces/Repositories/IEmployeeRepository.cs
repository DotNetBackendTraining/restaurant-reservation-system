using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.Domain.Interfaces.Repositories;

public interface IEmployeeRepository
{
    IAsyncEnumerable<Employee> GetAllManagersAsync();
    Task<EmployeeRestaurantDetail?> GetEmployeeRestaurantDetailAsync(int employeeId);
    Task<double> CalculateAverageOrderAmountAsync(int employeeId);
}