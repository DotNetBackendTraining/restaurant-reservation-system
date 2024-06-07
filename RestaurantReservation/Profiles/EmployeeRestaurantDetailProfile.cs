using AutoMapper;
using RestaurantReservation.Domain.Models;
using RestaurantReservation.DTOs;

namespace RestaurantReservation.Profiles;

public class EmployeeRestaurantDetailProfile : Profile
{
    public EmployeeRestaurantDetailProfile()
    {
        CreateMap<EmployeeRestaurantDetail, EmployeeRestaurantDetailDto>();
        CreateMap<EmployeeRestaurantDetailDto, EmployeeRestaurantDetail>();
    }
}