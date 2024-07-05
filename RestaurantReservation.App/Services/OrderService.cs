using AutoMapper;
using RestaurantReservation.App.DTOs;
using RestaurantReservation.App.Interfaces.Services;
using RestaurantReservation.Domain.Interfaces.Repositories;

namespace RestaurantReservation.App.Services;

public class OrderService : IOrderService
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;

    public OrderService(
        IMapper mapper, IOrderRepository orderRepository)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
    }

    public async Task<OrderDto?> GetOrderAsync(int orderId)
    {
        var order = await _orderRepository.GetOrderAsync(orderId);
        return _mapper.Map<OrderDto>(order);
    }

    public async Task<IEnumerable<FullOrderDto>> ListOrdersAndMenuItemsAsync(int reservationId)
    {
        var pairs = await _orderRepository.GetAllOrdersAndMenuItemsAsync(reservationId)
            .ToListAsync();

        return pairs.Select(pair => new FullOrderDto(
            _mapper.Map<OrderDto>(pair.Item1),
            pair.Item2.Select(mi => _mapper.Map<MenuItemDto>(mi)).ToList()));
    }

    public async Task<IEnumerable<MenuItemDto>> ListOrderedMenuItemsAsync(int reservationId)
    {
        var menuItems = await _orderRepository
            .GetAllOrderedMenuItemsAsync(reservationId)
            .ToListAsync();

        return menuItems.Select(mi => _mapper.Map<MenuItemDto>(mi));
    }
}