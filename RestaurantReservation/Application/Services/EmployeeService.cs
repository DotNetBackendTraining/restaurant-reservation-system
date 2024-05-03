using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Application.DTOs;
using RestaurantReservation.Application.Interfaces.Services;
using RestaurantReservation.Domain.Interfaces.Repositories;
using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IMapper _mapper;
    private readonly IQueryRepository<Employee> _queryRepository;
    private readonly IQueryRepository<EmployeeRestaurantDetail> _detailQueryRepository;

    public EmployeeService(
        IMapper mapper,
        IQueryRepository<Employee> queryRepository,
        IQueryRepository<EmployeeRestaurantDetail> detailQueryRepository)
    {
        _mapper = mapper;
        _queryRepository = queryRepository;
        _detailQueryRepository = detailQueryRepository;
    }

    public IAsyncEnumerable<EmployeeDto> GetAllManagersAsync()
    {
        return _queryRepository.GetAll()
            .Where(e => e.Position == "Manager")
            .AsAsyncEnumerable()
            .Select(e => _mapper.Map<EmployeeDto>(e));
    }

    public async Task<EmployeeRestaurantDetailDto> GetEmployeeRestaurantDetailAsync(int employeeId)
    {
        var employeeRestaurantDetail = await _detailQueryRepository.FindAsync(employeeId);
        return _mapper.Map<EmployeeRestaurantDetailDto>(employeeRestaurantDetail);
    }

    public async Task<double> CalculateAverageOrderAmountAsync(int employeeId)
    {
        return await _queryRepository.GetAll()
            .Where(e => e.EmployeeId == employeeId)
            .SelectMany(e => e.Orders)
            .AverageAsync(o => o.TotalAmount);
    }
}