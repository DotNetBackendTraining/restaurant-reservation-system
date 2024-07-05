namespace RestaurantReservation.App.DTOs;

public record ReservationDto(
    int ReservationId,
    int CustomerId,
    int TableId,
    DateTime ReservationDate,
    int PartySize)
{
}