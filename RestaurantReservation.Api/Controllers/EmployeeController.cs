using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.App.DTOs;
using RestaurantReservation.App.Interfaces.Services;

namespace RestaurantReservation.Api.Controllers;

[Route("api/employees")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("managers")]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAllManagers()
    {
        var managers = await _employeeService.GetAllManagersAsync();
        return Ok(managers);
    }

    [HttpGet("{employeeId:int}/average-order-amount")]
    public async Task<ActionResult<double>> GetAverageOrderAmount(int employeeId)
    {
        var averageOrderAmount = await _employeeService.CalculateAverageOrderAmountAsync(employeeId);
        if (averageOrderAmount == null)
        {
            return NotFound();
        }

        return Ok(averageOrderAmount);
    }
}