using AutoMapper;
using RestaurantReservation.Application.DTOs;
using RestaurantReservation.Application.Interfaces.Services;
using RestaurantReservation.Domain.Interfaces.Repositories;

namespace RestaurantReservation.Application.Services;

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

    public async Task<IEnumerable<EmployeeDto>> GetAllManagersAsync()
    {
        var managers = await _employeeRepository
            .GetAllManagersAsync()
            .ToListAsync();

        return managers.Select(e => _mapper.Map<EmployeeDto>(e));
    }

    public async Task<EmployeeRestaurantDetailDto> GetEmployeeRestaurantDetailAsync(int employeeId)
    {
        var employeeRestaurantDetail = await _employeeRepository.GetEmployeeRestaurantDetailAsync(employeeId);
        return _mapper.Map<EmployeeRestaurantDetailDto>(employeeRestaurantDetail);
    }

    public async Task<double> CalculateAverageOrderAmountAsync(int employeeId)
    {
        return await _employeeRepository.CalculateAverageOrderAmountAsync(employeeId);
    }

    public async Task<decimal> GetTotalRevenueByRestaurant(int restaurantId)
    {
        return await _employeeRepository.GetTotalRevenueByRestaurant(restaurantId);
    }
}