using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.Domain.Interfaces.Repositories;

public interface IOrderRepository
{
    IAsyncEnumerable<(Order, IList<MenuItem>)> GetAllOrdersAndMenuItemsAsync(int reservationId);
    IAsyncEnumerable<MenuItem> GetAllOrderedMenuItemsAsync(int orderId);
}