using AutoMapper;
using RestaurantReservation.Application.DTOs;
using RestaurantReservation.Application.Interfaces.Services;
using RestaurantReservation.Domain.Interfaces.Repositories;

namespace RestaurantReservation.Application.Services;

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

    public IAsyncEnumerable<FullOrderDto> ListOrdersAndMenuItemsAsync(int reservationId)
    {
        return _orderRepository.GetAllOrdersAndMenuItemsAsync(reservationId)
            .Select(pair => new FullOrderDto(
                _mapper.Map<OrderDto>(pair.Item1),
                pair.Item2.Select(mi => _mapper.Map<MenuItemDto>(mi)).ToList()));
    }

    public IAsyncEnumerable<MenuItemDto> ListOrderedMenuItemsAsync(int reservationId)
    {
        return _orderRepository.GetAllOrderedMenuItemsAsync(reservationId)
            .Select(mi => _mapper.Map<MenuItemDto>(mi));
    }
}