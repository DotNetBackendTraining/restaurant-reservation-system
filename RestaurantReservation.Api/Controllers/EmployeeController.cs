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
    private readonly ICudService<EmployeeDto> _cudService;

    public EmployeeController(
        IEmployeeService employeeService,
        ICudService<EmployeeDto> cudService)
    {
        _employeeService = employeeService;
        _cudService = cudService;
    }

    [HttpGet("{employeeId:int}")]
    public async Task<ActionResult<EmployeeDto>> GetEmployee(int employeeId)
    {
        var employee = await _employeeService.GetEmployee(employeeId);
        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);
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

    [HttpPost]
    public async Task<ActionResult<EmployeeDto>> CreateEmployee(EmployeeDto employeeDto)
    {
        var createdDto = await _cudService.CreateAsync(employeeDto);
        return CreatedAtAction(nameof(GetEmployee), new { employeeId = createdDto.EmployeeId }, createdDto);
    }
}