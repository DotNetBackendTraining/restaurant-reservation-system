using AutoMapper;
using RestaurantReservation.App.Common;
using RestaurantReservation.App.DTOs;
using RestaurantReservation.App.Interfaces.Services;
using RestaurantReservation.Domain.Interfaces.Repositories;
using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.App.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IMapper _mapper;
    private readonly ICommandRepository<Employee> _commandRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(
        IMapper mapper,
        ICommandRepository<Employee> commandRepository,
        IEmployeeRepository employeeRepository)
    {
        _mapper = mapper;
        _commandRepository = commandRepository;
        _employeeRepository = employeeRepository;
    }

    public async Task<Result<EmployeeDto>> CreateAsync(EmployeeDto dto)
    {
        var employee = _mapper.Map<Employee>(dto);
        _commandRepository.Add(employee);
        await _commandRepository.SaveChangesAsync();
        return Result<EmployeeDto>.Success(_mapper.Map<EmployeeDto>(employee));
    }

    public async Task<Result> UpdateAsync(EmployeeDto dto)
    {
        var existingEmployee = await _employeeRepository.GetEmployee(dto.EmployeeId);
        if (existingEmployee == null)
        {
            return Result.Failure("Employee not found");
        }

        _mapper.Map(dto, existingEmployee);
        _commandRepository.Update(existingEmployee);
        await _commandRepository.SaveChangesAsync();
        return Result.Success();
    }

    public async Task<Result> DeleteAsync(EmployeeDto dto)
    {
        var employee = await _employeeRepository.GetEmployee(dto.EmployeeId);
        if (employee == null)
        {
            return Result.Failure("Employee not found");
        }

        _commandRepository.Delete(employee);
        await _commandRepository.SaveChangesAsync();
        return Result.Success();
    }

    public async Task<Result<EmployeeDto>> GetEmployee(int employeeId)
    {
        var employee = await _employeeRepository.GetEmployee(employeeId);
        return employee == null
            ? Result<EmployeeDto>.Failure("Employee not found")
            : Result<EmployeeDto>.Success(_mapper.Map<EmployeeDto>(employee));
    }

    public async Task<Result<IEnumerable<EmployeeDto>>> GetAllManagersAsync()
    {
        var managers = await _employeeRepository.GetAllManagersAsync().ToListAsync();
        var managerDtos = managers.Select(e => _mapper.Map<EmployeeDto>(e));
        return Result<IEnumerable<EmployeeDto>>.Success(managerDtos);
    }

    public async Task<Result<EmployeeRestaurantDetailDto>> GetEmployeeRestaurantDetailAsync(int employeeId)
    {
        var employeeRestaurantDetail = await _employeeRepository.GetEmployeeRestaurantDetailAsync(employeeId);
        if (employeeRestaurantDetail == null)
        {
            return Result<EmployeeRestaurantDetailDto>.Failure("Employee restaurant detail not found");
        }

        return Result<EmployeeRestaurantDetailDto>.Success(
            _mapper.Map<EmployeeRestaurantDetailDto>(employeeRestaurantDetail));
    }

    public async Task<Result<double>> CalculateAverageOrderAmountAsync(int employeeId)
    {
        try
        {
            var averageOrderAmount = await _employeeRepository.CalculateAverageOrderAmountAsync(employeeId);
            return Result<double>.Success(averageOrderAmount);
        }
        catch (InvalidOperationException)
        {
            return Result<double>.Failure("Error calculating average order amount");
        }
    }

    public async Task<Result<decimal>> GetTotalRevenueByRestaurant(int restaurantId)
    {
        try
        {
            var totalRevenue = await _employeeRepository.GetTotalRevenueByRestaurant(restaurantId);
            return Result<decimal>.Success(totalRevenue);
        }
        catch (InvalidOperationException)
        {
            return Result<decimal>.Failure($"Error calculating total revenue");
        }
    }
}