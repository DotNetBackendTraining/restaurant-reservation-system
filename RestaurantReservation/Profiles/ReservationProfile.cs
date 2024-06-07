using AutoMapper;
using RestaurantReservation.Domain.Models;
using RestaurantReservation.DTOs;

namespace RestaurantReservation.Profiles;

public class ReservationProfile : Profile
{
    public ReservationProfile()
    {
        CreateMap<Reservation, ReservationDto>();
        CreateMap<ReservationDto, Reservation>();
    }
}