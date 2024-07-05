using RestaurantReservation.App.DTOs;

namespace RestaurantReservation.App.Interfaces.Services;

public interface IOrderService
{
    Task<OrderDto?> GetOrderAsync(int orderId);

    Task<IEnumerable<FullOrderDto>> ListOrdersAndMenuItemsAsync(int reservationId);

    Task<IEnumerable<MenuItemDto>> ListOrderedMenuItemsAsync(int reservationId);
}