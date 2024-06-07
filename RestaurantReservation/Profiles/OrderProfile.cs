using AutoMapper;
using RestaurantReservation.Domain.Models;
using RestaurantReservation.DTOs;

namespace RestaurantReservation.Profiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderDto>();
        CreateMap<OrderDto, Order>();
    }
}