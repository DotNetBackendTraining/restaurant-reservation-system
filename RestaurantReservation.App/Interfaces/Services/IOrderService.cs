using RestaurantReservation.App.DTOs;

namespace RestaurantReservation.App.Interfaces.Services;

public interface IOrderService
{
    Task<OrderDto?> GetOrderAsync(int orderId);
}