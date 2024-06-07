using RestaurantReservation.App.DTOs;

namespace RestaurantReservation.App.Interfaces.Services;

public interface IOrderService
{
    Task<IEnumerable<FullOrderDto>> ListOrdersAndMenuItemsAsync(int reservationId);

    Task<IEnumerable<MenuItemDto>> ListOrderedMenuItemsAsync(int reservationId);
}