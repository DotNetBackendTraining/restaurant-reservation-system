using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.Domain.Interfaces.Repositories;

public interface IOrderRepository
{
    IAsyncEnumerable<Order> GetAllOrdersAsync(int reservationId);
    IAsyncEnumerable<MenuItem> GetAllOrderedMenuItemsAsync(int orderId);
}