using AutoMapper;
using RestaurantReservation.Domain.Models;
using RestaurantReservation.DTOs;

namespace RestaurantReservation.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerDto>();
        CreateMap<CustomerDto, Customer>();
    }
}