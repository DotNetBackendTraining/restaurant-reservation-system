using AutoMapper;
using RestaurantReservation.App.DTOs;
using RestaurantReservation.App.Interfaces.Services;
using RestaurantReservation.Domain.Interfaces.Repositories;

namespace RestaurantReservation.App.Services;

public class CustomerService : ICustomerService
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(
        IMapper mapper,
        ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<CustomerDto?> GetCustomerAsync(int customerId)
    {
        var customer = await _customerRepository.GetCustomer(customerId);
        return _mapper.Map<CustomerDto>(customer);
    }

    public async Task<IEnumerable<CustomerDto>> GetCustomersWithPartySizeGreaterThanAsync(int partySize)
    {
        var customers = await _customerRepository
            .GetCustomersWithPartySizeGreaterThan(partySize)
            .ToListAsync();

        return customers.Select(c => _mapper.Map<CustomerDto>(c));
    }
}