using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Domain.Interfaces.Services;

public interface IOrderService
{
    IAsyncEnumerable<(Order, IList<MenuItem>)> ListOrdersAndMenuItems(int reservationId);

    IAsyncEnumerable<MenuItem> ListOrderedMenuItems(int reservationId);
}