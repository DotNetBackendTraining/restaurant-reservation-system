using AutoMapper;
using RestaurantReservation.Application.DTOs;
using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.Application.Profiles;

public class MenuItemProfile : Profile
{
    public MenuItemProfile()
    {
        CreateMap<MenuItem, MenuItemDto>();
        CreateMap<MenuItemDto, MenuItem>();
    }
}