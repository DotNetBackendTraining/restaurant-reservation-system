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
        return _orderRepository
            .GetAllOrdersAsync(reservationId)
            .SelectAwait(async order => new FullOrderDto(
                _mapper.Map<OrderDto>(order),
                await _orderRepository
                    .GetAllOrderedMenuItemsAsync(order.OrderId)
                    .Select(mi => _mapper.Map<MenuItemDto>(mi))
                    .ToListAsync()));
    }

    public IAsyncEnumerable<MenuItemDto> ListOrderedMenuItemsAsync(int reservationId)
    {
        return _orderRepository.GetAllOrderedMenuItemsAsync(reservationId)
            .Select(mi => _mapper.Map<MenuItemDto>(mi));
    }
}