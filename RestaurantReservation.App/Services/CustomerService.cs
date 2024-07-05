using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.App.Common;
using RestaurantReservation.App.DTOs;
using RestaurantReservation.App.Interfaces.Services;
using RestaurantReservation.Domain.Interfaces.Repositories;
using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.App.Services;

public class CustomerService : ICustomerService
{
    private readonly IMapper _mapper;
    private readonly ICommandRepository<Customer> _commandRepository;
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(
        IMapper mapper,
        ICommandRepository<Customer> commandRepository,
        ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _commandRepository = commandRepository;
        _customerRepository = customerRepository;
    }

    public async Task<Result<CustomerDto>> CreateAsync(CustomerDto dto)
    {
        var customer = _mapper.Map<Customer>(dto);
        var validationResult = await ValidateUniqueEmailAsync(customer);
        if (!validationResult.IsSuccess)
        {
            return Result<CustomerDto>.Failure(validationResult.ErrorMessage);
        }

        _commandRepository.Add(customer);
        await _commandRepository.SaveChangesAsync();
        return Result<CustomerDto>.Success(_mapper.Map<CustomerDto>(customer));
    }

    public async Task<Result> UpdateAsync(CustomerDto dto)
    {
        var customer = _mapper.Map<Customer>(dto);
        var validationResult = await ValidateUniqueEmailAsync(customer);
        if (!validationResult.IsSuccess)
        {
            return Result.Failure(validationResult.ErrorMessage);
        }

        var existingCustomer = await _customerRepository.GetCustomer(dto.CustomerId);
        if (existingCustomer == null)
        {
            return Result.Failure("Customer not found");
        }

        _mapper.Map(dto, existingCustomer);
        _commandRepository.Update(existingCustomer);
        await _commandRepository.SaveChangesAsync();
        return Result.Success();
    }

    public async Task<Result> DeleteAsync(CustomerDto dto)
    {
        var customer = await _customerRepository.GetCustomer(dto.CustomerId);
        if (customer == null)
        {
            return Result.Failure("Customer not found");
        }

        _commandRepository.Delete(customer);
        await _commandRepository.SaveChangesAsync();
        return Result.Success();
    }

    public async Task<Result<CustomerDto>> GetCustomerAsync(int customerId)
    {
        var customer = await _customerRepository.GetCustomer(customerId);
        return customer == null
            ? Result<CustomerDto>.Failure("Customer not found")
            : Result<CustomerDto>.Success(_mapper.Map<CustomerDto>(customer));
    }

    public async Task<Result<IEnumerable<CustomerDto>>> GetCustomersWithPartySizeGreaterThanAsync(int partySize)
    {
        var customers = await _customerRepository
            .GetCustomersWithPartySizeGreaterThan(partySize)
            .ToListAsync();

        var customerDtos = customers.Select(c => _mapper.Map<CustomerDto>(c));
        return Result<IEnumerable<CustomerDto>>.Success(customerDtos);
    }

    private async Task<Result> ValidateUniqueEmailAsync(Customer customer)
    {
        var existingCustomer = await _customerRepository.GetCustomerByEmailAsync(customer.Email);
        if (existingCustomer != null && existingCustomer.CustomerId != customer.CustomerId)
        {
            return Result.Failure("Customer with this email already exists");
        }

        return Result.Success();
    }
}