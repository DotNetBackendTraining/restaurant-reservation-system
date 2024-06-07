using AutoMapper;
using RestaurantReservation.Domain.Interfaces.Repositories;
using RestaurantReservation.DTOs;
using RestaurantReservation.Interfaces.Services;

namespace RestaurantReservation.Services;

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