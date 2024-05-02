using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Application.DTOs;
using RestaurantReservation.Application.Interfaces.Services;
using RestaurantReservation.Db.Interfaces.Repositories;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IQueryRepository<Employee> _queryRepository;
    private readonly IMapper _mapper;

    public EmployeeService(
        IQueryRepository<Employee> queryRepository,
        IMapper mapper)
    {
        _queryRepository = queryRepository;
        _mapper = mapper;
    }

    public IAsyncEnumerable<EmployeeDto> GetAllManagersAsync()
    {
        return _queryRepository.GetAll()
            .Where(e => e.Position == "Manager")
            .AsAsyncEnumerable()
            .Select(e => _mapper.Map<EmployeeDto>(e));
    }

    public async Task<double> CalculateAverageOrderAmountAsync(int employeeId)
    {
        return await _queryRepository.GetAll()
            .Where(e => e.EmployeeId == employeeId)
            .SelectMany(e => e.Orders)
            .AverageAsync(o => o.TotalAmount);
    }
}