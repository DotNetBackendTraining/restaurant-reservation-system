using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Domain.Interfaces.Repositories;
using RestaurantReservation.Domain.Interfaces.Services;

namespace RestaurantReservation.Domain.Services;

public class OrderService : IOrderService
{
    private readonly IQueryRepository<Order> _queryRepository;

    public OrderService(IQueryRepository<Order> queryRepository)
    {
        _queryRepository = queryRepository;
    }

    public async IAsyncEnumerable<(Order, IList<MenuItem>)> ListOrdersAndMenuItems(int reservationId)
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
}