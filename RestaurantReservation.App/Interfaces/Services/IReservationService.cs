using RestaurantReservation.App.Common;
using RestaurantReservation.App.DTOs;

namespace RestaurantReservation.App.Interfaces.Services;

public interface IReservationService
{
    Task<Result<ReservationDto>> CreateAsync(ReservationDto dto);

    Task<Result> UpdateAsync(ReservationDto dto);

    Task<Result> DeleteAsync(ReservationDto dto);

    Task<Result<ReservationDto>> GetReservationAsync(int reservationId);

    Task<Result<IEnumerable<ReservationDto>>> GetReservationsByCustomerAsync(int customerId);

    Task<Result<ReservationDetailDto>> GetReservationDetailAsync(int reservationId);
}