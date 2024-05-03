using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Application.DTOs;
using RestaurantReservation.Application.Interfaces.Services;
using RestaurantReservation.Domain.Interfaces.Repositories;
using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.Application.Services;

public class OrderService : IOrderService
{
    private readonly IQueryRepository<Order> _queryRepository;
    private readonly IMapper _mapper;

    public OrderService(
        IQueryRepository<Order> queryRepository,
        IMapper mapper)
    {
        _queryRepository = queryRepository;
        _mapper = mapper;
    }

    public IAsyncEnumerable<FullOrderDto> ListOrdersAndMenuItemsAsync(int reservationId)
    {
        return _queryRepository.GetAll()
            .Where(o => o.ReservationId == reservationId)
            .Select(o => new
            {
                Order = o,
                MenuItems = _queryRepository.GetAll()
                    .Where(o1 => o1.OrderId == o.OrderId)
                    .SelectMany(o1 => o1.OrderItems)
                    .Select(oi => oi.MenuItem)
                    .ToList()
            })
            .AsAsyncEnumerable()
            .Select(pair => new FullOrderDto(
                _mapper.Map<OrderDto>(pair.Order),
                pair.MenuItems.Select(mi => _mapper.Map<MenuItemDto>(mi)).ToList()));
    }

    public IAsyncEnumerable<MenuItemDto> ListOrderedMenuItemsAsync(int reservationId)
    {
        return _queryRepository.GetAll()
            .Where(o => o.ReservationId == reservationId)
            .SelectMany(order => order.OrderItems)
            .Select(orderItem => orderItem.MenuItem)
            .Distinct()
            .AsAsyncEnumerable()
            .Select(mi => _mapper.Map<MenuItemDto>(mi));
    }
}