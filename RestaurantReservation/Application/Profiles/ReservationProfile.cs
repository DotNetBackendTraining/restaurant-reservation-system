using AutoMapper;
using RestaurantReservation.Application.DTOs;
using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.Application.Profiles;

public class ReservationProfile : Profile
{
    public ReservationProfile()
    {
        CreateMap<Reservation, ReservationDto>();
        CreateMap<ReservationDto, Reservation>();
    }
}