using RestaurantReservation.App.DTOs;

namespace RestaurantReservation.App.Interfaces.Services;

public interface IEmployeeService
{
    Task<EmployeeDto?> GetEmployee(int employeeId);

    Task<IEnumerable<EmployeeDto>> GetAllManagersAsync();

    Task<EmployeeRestaurantDetailDto?> GetEmployeeRestaurantDetailAsync(int employeeId);

    Task<double?> CalculateAverageOrderAmountAsync(int employeeId);

    Task<decimal?> GetTotalRevenueByRestaurant(int restaurantId);
}