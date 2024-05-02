using RestaurantReservation.Application.DTOs;

namespace RestaurantReservation.Application.Interfaces.Services;

public interface IEmployeeService
{
    IAsyncEnumerable<EmployeeDto> GetAllManagersAsync();

    Task<EmployeeRestaurantDetailDto> GetEmployeeRestaurantDetailAsync(int employeeId);

    Task<double> CalculateAverageOrderAmountAsync(int employeeId);
}