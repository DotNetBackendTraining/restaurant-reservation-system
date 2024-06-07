using AutoMapper;
using RestaurantReservation.App.DTOs;
using RestaurantReservation.App.Interfaces.Services;
using RestaurantReservation.Domain.Interfaces.Repositories;

namespace RestaurantReservation.App.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IMapper _mapper;
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(
        IMapper mapper,
        IEmployeeRepository employeeRepository)
    {
        _mapper = mapper;
        _employeeRepository = employeeRepository;
    }

    public async Task<EmployeeDto?> GetEmployee(int employeeId)
    {
        var employee = await _employeeRepository.GetEmployee(employeeId);
        return _mapper.Map<EmployeeDto>(employee);
    }

    public async Task<IEnumerable<EmployeeDto>> GetAllManagersAsync()
    {
        var managers = await _employeeRepository
            .GetAllManagersAsync()
            .ToListAsync();

        return managers.Select(e => _mapper.Map<EmployeeDto>(e));
    }

    public async Task<EmployeeRestaurantDetailDto?> GetEmployeeRestaurantDetailAsync(int employeeId)
    {
        var employeeRestaurantDetail = await _employeeRepository.GetEmployeeRestaurantDetailAsync(employeeId);
        return employeeRestaurantDetail is null
            ? null
            : _mapper.Map<EmployeeRestaurantDetailDto>(employeeRestaurantDetail);
    }

    public async Task<double?> CalculateAverageOrderAmountAsync(int employeeId)
    {
        try
        {
            return await _employeeRepository.CalculateAverageOrderAmountAsync(employeeId);
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }

    public async Task<decimal?> GetTotalRevenueByRestaurant(int restaurantId)
    {
        try
        {
            return await _employeeRepository.GetTotalRevenueByRestaurant(restaurantId);
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }
}