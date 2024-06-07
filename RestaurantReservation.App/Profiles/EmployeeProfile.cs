using AutoMapper;
using RestaurantReservation.App.DTOs;
using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.App.Profiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeDto>();
        CreateMap<EmployeeDto, Employee>();
    }
}