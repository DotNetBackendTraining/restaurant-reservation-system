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

    public IAsyncEnumerable<Order> GetAllOrdersAsync(int reservationId)
    {
        return _context.Orders
            .Where(o => o.ReservationId == reservationId)
            .AsAsyncEnumerable();
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