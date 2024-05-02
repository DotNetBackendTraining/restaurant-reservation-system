using AutoMapper;
using RestaurantReservation.Application.DTOs;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Application;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Employee, EmployeeDto>();
        CreateMap<EmployeeDto, Employee>();

        CreateMap<MenuItem, MenuItemDto>();
        CreateMap<MenuItemDto, MenuItem>();

        CreateMap<Order, OrderDto>();
        CreateMap<OrderDto, Order>();

        CreateMap<Reservation, ReservationDto>();
        CreateMap<ReservationDto, Reservation>();

        CreateMap<ReservationDetail, ReservationDetailDto>();
        CreateMap<ReservationDetailDto, ReservationDetail>();
    }
}