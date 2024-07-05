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
}