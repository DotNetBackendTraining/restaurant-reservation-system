using RestaurantReservation.App.Common;
using RestaurantReservation.App.DTOs;

namespace RestaurantReservation.App.Interfaces.Services;

public interface IEmployeeService
{
    Task<Result<EmployeeDto>> CreateAsync(EmployeeDto dto);

    Task<Result> UpdateAsync(EmployeeDto dto);

    Task<Result> DeleteAsync(EmployeeDto dto);

    Task<Result<EmployeeDto>> GetEmployee(int employeeId);

    Task<Result<IEnumerable<EmployeeDto>>> GetAllManagersAsync();

    Task<Result<EmployeeRestaurantDetailDto>> GetEmployeeRestaurantDetailAsync(int employeeId);

    Task<Result<double>> CalculateAverageOrderAmountAsync(int employeeId);

    Task<Result<decimal>> GetTotalRevenueByRestaurant(int restaurantId);
}