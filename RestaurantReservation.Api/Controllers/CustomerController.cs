using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.App.DTOs;
using RestaurantReservation.App.Interfaces.Services;

namespace RestaurantReservation.Api.Controllers;

[Route("api/customers")]
[ApiController]
[Authorize]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("{customerId:int}")]
    public async Task<ActionResult<CustomerDto>> GetCustomer(int customerId)
    {
        var result = await _customerService.GetCustomerAsync(customerId);
        if (!result.IsSuccess)
        {
            return NotFound(result.ErrorMessage);
        }

        return Ok(result.GetDataOrThrow());
    }

    [HttpPost]
    public async Task<ActionResult<CustomerDto>> CreateCustomer(CustomerDto customerDto)
    {
        var result = await _customerService.CreateAsync(customerDto);
        if (!result.IsSuccess)
        {
            return Conflict(result.ErrorMessage);
        }

        return CreatedAtAction(
            nameof(GetCustomer),
            new { customerId = result.GetDataOrThrow().CustomerId },
            result.GetDataOrThrow());
    }

    [HttpPut("{customerId:int}")]
    public async Task<IActionResult> UpdateCustomer(int customerId, CustomerDto customerDto)
    {
        var updatedDto = customerDto with { CustomerId = customerId };
        var result = await _customerService.UpdateAsync(updatedDto);
        if (!result.IsSuccess)
        {
            return Conflict(result.ErrorMessage);
        }

        return NoContent();
    }

    [HttpDelete("{customerId:int}")]
    public async Task<IActionResult> DeleteCustomer(int customerId)
    {
        var customerResult = await _customerService.GetCustomerAsync(customerId);
        if (!customerResult.IsSuccess)
        {
            return NotFound(customerResult.ErrorMessage);
        }

        var deleteResult = await _customerService.DeleteAsync(customerResult.GetDataOrThrow());
        if (!deleteResult.IsSuccess)
        {
            return Conflict(deleteResult.ErrorMessage);
        }

        return NoContent();
    }

    [HttpGet("party-size-greater-than/{partySize:int}")]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomersWithPartySizeGreaterThan(int partySize)
    {
        var result = await _customerService.GetCustomersWithPartySizeGreaterThanAsync(partySize);
        if (!result.IsSuccess)
        {
            return BadRequest(result.ErrorMessage);
        }

        return Ok(result.GetDataOrThrow());
    }
}