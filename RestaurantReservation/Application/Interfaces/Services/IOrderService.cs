using RestaurantReservation.Application.DTOs;

namespace RestaurantReservation.Application.Interfaces.Services;

public interface IOrderService
{
    IAsyncEnumerable<FullOrderDto> ListOrdersAndMenuItemsAsync(int reservationId);

    IAsyncEnumerable<MenuItemDto> ListOrderedMenuItemsAsync(int reservationId);
}