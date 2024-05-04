using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Interfaces.Repositories;
using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.Db.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly RestaurantReservationDbContext _context;

    public OrderRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async IAsyncEnumerable<(Order, IList<MenuItem>)> GetAllOrdersAndMenuItemsAsync(int reservationId)
    {
        var pairs = _context.Orders
            .Where(o => o.ReservationId == reservationId)
            .Select(o => new
            {
                Order = o,
                MenuItems = _context.OrderItems
                    .Where(oi => oi.OrderId == o.OrderId)
                    .Select(oi => oi.MenuItem)
                    .ToList()
            });

        await foreach (var pair in pairs.AsAsyncEnumerable())
        {
            yield return (pair.Order, pair.MenuItems);
        }
    }

    public IAsyncEnumerable<MenuItem> GetAllOrderedMenuItemsAsync(int orderId)
    {
        return _context.OrderItems
            .Where(oi => oi.OrderId == orderId)
            .Select(oi => oi.MenuItem)
            .Distinct()
            .AsAsyncEnumerable();
    }
}