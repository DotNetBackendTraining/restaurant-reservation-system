using AutoMapper;
using RestaurantReservation.App.DTOs;
using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.App.Profiles;

public class MenuItemProfile : Profile
{
    public MenuItemProfile()
    {
        CreateMap<MenuItem, MenuItemDto>();
        CreateMap<MenuItemDto, MenuItem>();
    }
}