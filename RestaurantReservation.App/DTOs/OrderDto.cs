namespace RestaurantReservation.App.DTOs;

public record OrderDto(
    int OrderId,
    DateTime OrderDate,
    double TotalAmount)
{
}