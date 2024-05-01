using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Domain.Interfaces.Services;

public interface IEmployeeService
{
    IAsyncEnumerable<Employee> GetAllManagersAsync();

    Task<double> CalculateAverageOrderAmountAsync(int employeeId);
}