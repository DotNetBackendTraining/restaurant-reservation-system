using RestaurantReservation.Application.DTOs;

namespace RestaurantReservation.Application.Interfaces.Services;

public interface IOrderService
{
    Task<IEnumerable<FullOrderDto>> ListOrdersAndMenuItemsAsync(int reservationId);

    Task<IEnumerable<MenuItemDto>> ListOrderedMenuItemsAsync(int reservationId);
}