using AutoMapper;
using RestaurantReservation.App.DTOs;
using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.App.Profiles;

public class ReservationDetailProfile : Profile
{
    public ReservationDetailProfile()
    {
        CreateMap<ReservationDetail, ReservationDetailDto>();
        CreateMap<ReservationDetailDto, ReservationDetail>();
    }
}