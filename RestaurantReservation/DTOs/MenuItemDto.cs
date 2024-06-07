namespace RestaurantReservation.DTOs;

public record MenuItemDto(
    int ItemId,
    string Name,
    string Description,
    double Price)
{
}