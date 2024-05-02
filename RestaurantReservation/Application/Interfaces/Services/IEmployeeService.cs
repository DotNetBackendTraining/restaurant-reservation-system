using RestaurantReservation.Application.DTOs;

namespace RestaurantReservation.Application.Interfaces.Services;

public interface IEmployeeService
{
    IAsyncEnumerable<EmployeeDto> GetAllManagersAsync();

    Task<double> CalculateAverageOrderAmountAsync(int employeeId);
}