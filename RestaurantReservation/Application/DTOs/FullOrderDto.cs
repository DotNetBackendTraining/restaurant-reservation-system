namespace RestaurantReservation.Application.DTOs;

public record FullOrderDto(
    OrderDto Order,
    IReadOnlyList<MenuItemDto> MenuItems)
{
}