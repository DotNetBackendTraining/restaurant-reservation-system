using RestaurantReservation.Application.DTOs;

namespace RestaurantReservation.Application.Interfaces.Services;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDto>> GetAllManagersAsync();

    Task<EmployeeRestaurantDetailDto?> GetEmployeeRestaurantDetailAsync(int employeeId);

    Task<double> CalculateAverageOrderAmountAsync(int employeeId);

    Task<decimal> GetTotalRevenueByRestaurant(int restaurantId);
}