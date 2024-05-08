using AutoMapper;
using RestaurantReservation.Application.DTOs;
using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.Application.Profiles;

public class EmployeeRestaurantDetailProfile : Profile
{
    public EmployeeRestaurantDetailProfile()
    {
        CreateMap<EmployeeRestaurantDetail, EmployeeRestaurantDetailDto>();
        CreateMap<EmployeeRestaurantDetailDto, EmployeeRestaurantDetail>();
    }
}