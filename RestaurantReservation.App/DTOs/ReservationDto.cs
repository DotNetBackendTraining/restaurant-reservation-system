namespace RestaurantReservation.App.DTOs;

public record ReservationDto(
    int ReservationId,
    DateTime ReservationDate,
    int PartySize)
{
}