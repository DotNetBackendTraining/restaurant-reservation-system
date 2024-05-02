using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Application.Interfaces.Services;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Domain.Interfaces.Repositories;

namespace RestaurantReservation.Application.Services;

public class OrderService : IOrderService
{
    private readonly IQueryRepository<Order> _queryRepository;

    public OrderService(IQueryRepository<Order> queryRepository)
    {
        _queryRepository = queryRepository;
    }

    public async IAsyncEnumerable<(Order, IList<MenuItem>)> ListOrdersAndMenuItemsAsync(int reservationId)
    {
        var query = _queryRepository.GetAll()
            .Where(o => o.ReservationId == reservationId)
            .Select(o => new
            {
                Order = o,
                MenuItems = _queryRepository.GetAll()
                    .Where(o1 => o1.OrderId == o.OrderId)
                    .SelectMany(o1 => o1.OrderItems)
                    .Select(oi => oi.MenuItem)
                    .ToList()
            });

        await foreach (var pair in query.AsAsyncEnumerable())
        {
            yield return (pair.Order, pair.MenuItems);
        }
    }

    public IAsyncEnumerable<MenuItem> ListOrderedMenuItemsAsync(int reservationId)
    {
        return _queryRepository.GetAll()
            .Where(o => o.ReservationId == reservationId)
            .SelectMany(order => order.OrderItems)
            .Select(orderItem => orderItem.MenuItem)
            .Distinct()
            .AsAsyncEnumerable();
    }
}