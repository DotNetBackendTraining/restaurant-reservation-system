using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Domain.Interfaces.Services;

public interface IOrderService
{
    IAsyncEnumerable<(Order, IList<MenuItem>)> ListOrdersAndMenuItemsAsync(int reservationId);

    IAsyncEnumerable<MenuItem> ListOrderedMenuItemsAsync(int reservationId);
}