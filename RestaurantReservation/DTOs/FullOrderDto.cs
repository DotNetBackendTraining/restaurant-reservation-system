namespace RestaurantReservation.DTOs;

public record FullOrderDto(
    OrderDto Order,
    IReadOnlyList<MenuItemDto> MenuItems)
{
}