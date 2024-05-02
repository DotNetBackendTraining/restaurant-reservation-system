using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Application.Interfaces.Services;

public interface IEmployeeService
{
    IAsyncEnumerable<Employee> GetAllManagersAsync();

    Task<double> CalculateAverageOrderAmountAsync(int employeeId);
}