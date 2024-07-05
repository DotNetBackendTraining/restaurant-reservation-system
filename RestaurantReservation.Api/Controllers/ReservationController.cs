using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.App.DTOs;
using RestaurantReservation.App.Interfaces.Services;

namespace RestaurantReservation.Api.Controllers;

[Route("api/reservations")]
[ApiController]
[Authorize]
public class ReservationController : ControllerBase
{
    private readonly IReservationService _reservationService;

    public ReservationController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    [HttpGet("{reservationId:int}")]
    public async Task<ActionResult<ReservationDto>> GetReservation(int reservationId)
    {
        var result = await _reservationService.GetReservationAsync(reservationId);
        if (!result.IsSuccess)
        {
            return NotFound(result.ErrorMessage);
        }

        return Ok(result.GetDataOrThrow());
    }

    [HttpPost]
    public async Task<ActionResult<ReservationDto>> CreateReservation(ReservationDto reservationDto)
    {
        var result = await _reservationService.CreateAsync(reservationDto);
        if (!result.IsSuccess)
        {
            return Conflict(result.ErrorMessage);
        }

        return CreatedAtAction(
            nameof(GetReservation),
            new { reservationId = result.GetDataOrThrow().ReservationId },
            result.GetDataOrThrow());
    }

    [HttpPut("{reservationId:int}")]
    public async Task<IActionResult> UpdateReservation(int reservationId, ReservationDto reservationDto)
    {
        var updatedDto = reservationDto with { ReservationId = reservationId };
        var result = await _reservationService.UpdateAsync(updatedDto);
        if (!result.IsSuccess)
        {
            return Conflict(result.ErrorMessage);
        }

        return NoContent();
    }

    [HttpDelete("{reservationId:int}")]
    public async Task<IActionResult> DeleteReservation(int reservationId)
    {
        var reservationResult = await _reservationService.GetReservationAsync(reservationId);
        if (!reservationResult.IsSuccess)
        {
            return NotFound(reservationResult.ErrorMessage);
        }

        var deleteResult = await _reservationService.DeleteAsync(reservationResult.GetDataOrThrow());
        if (!deleteResult.IsSuccess)
        {
            return Conflict(deleteResult.ErrorMessage);
        }

        return NoContent();
    }

    [HttpGet("customer/{customerId:int}")]
    public async Task<ActionResult<IEnumerable<ReservationDto>>> GetReservationsByCustomer(int customerId)
    {
        var result = await _reservationService.GetReservationsByCustomerAsync(customerId);
        if (!result.IsSuccess)
        {
            return BadRequest(result.ErrorMessage);
        }

        return Ok(result.GetDataOrThrow());
    }

    [HttpGet("{reservationId:int}/detail")]
    public async Task<ActionResult<ReservationDetailDto>> GetReservationDetail(int reservationId)
    {
        var result = await _reservationService.GetReservationDetailAsync(reservationId);
        if (!result.IsSuccess)
        {
            return NotFound(result.ErrorMessage);
        }

        return Ok(result.GetDataOrThrow());
    }
}