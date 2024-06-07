using AutoMapper;
using RestaurantReservation.App.DTOs;
using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.App.Profiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderDto>();
        CreateMap<OrderDto, Order>();
    }
}