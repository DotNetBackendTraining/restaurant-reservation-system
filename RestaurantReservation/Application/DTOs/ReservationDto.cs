namespace RestaurantReservation.Application.DTOs;

public record ReservationDto(
    int ReservationId,
    DateTime ReservationDate,
    int PartySize)
{
}