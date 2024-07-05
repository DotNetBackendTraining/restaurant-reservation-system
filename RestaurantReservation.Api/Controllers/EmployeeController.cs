using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.App.DTOs;
using RestaurantReservation.App.Interfaces.Services;

namespace RestaurantReservation.Api.Controllers;

[Route("api/employees")]
[ApiController]
[Authorize]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("{employeeId:int}")]
    public async Task<ActionResult<EmployeeDto>> GetEmployee(int employeeId)
    {
        var result = await _employeeService.GetEmployee(employeeId);
        if (!result.IsSuccess)
        {
            return NotFound(result.ErrorMessage);
        }

        return Ok(result.GetDataOrThrow());
    }

    [HttpGet("managers")]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAllManagers()
    {
        var result = await _employeeService.GetAllManagersAsync();
        if (!result.IsSuccess)
        {
            return BadRequest(result.ErrorMessage);
        }

        return Ok(result.GetDataOrThrow());
    }

    [HttpGet("{employeeId:int}/average-order-amount")]
    public async Task<ActionResult<double>> GetAverageOrderAmount(int employeeId)
    {
        var result = await _employeeService.CalculateAverageOrderAmountAsync(employeeId);
        if (!result.IsSuccess)
        {
            return NotFound(result.ErrorMessage);
        }

        return Ok(result.GetDataOrThrow());
    }

    [HttpPost]
    public async Task<ActionResult<EmployeeDto>> CreateEmployee(EmployeeDto employeeDto)
    {
        var result = await _employeeService.CreateAsync(employeeDto);
        if (!result.IsSuccess)
        {
            return Conflict(result.ErrorMessage);
        }

        return CreatedAtAction(
            nameof(GetEmployee),
            new { employeeId = result.GetDataOrThrow().EmployeeId },
            result.GetDataOrThrow());
    }

    [HttpPut("{employeeId:int}")]
    public async Task<IActionResult> UpdateEmployee(int employeeId, EmployeeDto employeeDto)
    {
        var updatedDto = employeeDto with { EmployeeId = employeeId };
        var result = await _employeeService.UpdateAsync(updatedDto);
        if (!result.IsSuccess)
        {
            return Conflict(result.ErrorMessage);
        }

        return NoContent();
    }

    [HttpDelete("{employeeId:int}")]
    public async Task<IActionResult> DeleteEmployee(int employeeId)
    {
        var employeeResult = await _employeeService.GetEmployee(employeeId);
        if (!employeeResult.IsSuccess)
        {
            return NotFound(employeeResult.ErrorMessage);
        }

        var deleteResult = await _employeeService.DeleteAsync(employeeResult.GetDataOrThrow());
        if (!deleteResult.IsSuccess)
        {
            return Conflict(deleteResult.ErrorMessage);
        }

        return NoContent();
    }

    [HttpGet("{employeeId:int}/restaurant-detail")]
    public async Task<ActionResult<EmployeeRestaurantDetailDto>> GetEmployeeRestaurantDetail(int employeeId)
    {
        var result = await _employeeService.GetEmployeeRestaurantDetailAsync(employeeId);
        if (!result.IsSuccess)
        {
            return NotFound(result.ErrorMessage);
        }

        return Ok(result.GetDataOrThrow());
    }
}