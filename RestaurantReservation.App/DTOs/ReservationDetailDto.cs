namespace RestaurantReservation.App.DTOs;

public record ReservationDetailDto(
    int ReservationId,
    DateTime ReservationDate,
    int PartySize,
    string CustomerFirstName,
    string CustomerLastName,
    string CustomerEmail,
    string CustomerPhoneNumber,
    string RestaurantName,
    string RestaurantAddress,
    string RestaurantPhoneNumber,
    string RestaurantOpeningHours)
{
}