using AutoMapper;
using RestaurantReservation.App.DTOs;
using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.App.Profiles;

public class EmployeeRestaurantDetailProfile : Profile
{
    public EmployeeRestaurantDetailProfile()
    {
        CreateMap<EmployeeRestaurantDetail, EmployeeRestaurantDetailDto>();
        CreateMap<EmployeeRestaurantDetailDto, EmployeeRestaurantDetail>();
    }
}