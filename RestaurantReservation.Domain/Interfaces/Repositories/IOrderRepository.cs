using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.Domain.Interfaces.Repositories;

public interface IOrderRepository
{
    Task<Order?> GetOrderAsync(int orderId);
    IAsyncEnumerable<(Order, IList<MenuItem>)> GetAllOrdersAndMenuItemsAsync(int reservationId);
    IAsyncEnumerable<MenuItem> GetAllOrderedMenuItemsAsync(int orderId);
}