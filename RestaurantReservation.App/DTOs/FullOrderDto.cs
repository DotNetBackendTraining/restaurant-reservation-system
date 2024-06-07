namespace RestaurantReservation.App.DTOs;

public record FullOrderDto(
    OrderDto Order,
    IReadOnlyList<MenuItemDto> MenuItems)
{
}