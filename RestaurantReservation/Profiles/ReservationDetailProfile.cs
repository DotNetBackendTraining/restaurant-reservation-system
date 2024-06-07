using AutoMapper;
using RestaurantReservation.Domain.Models;
using RestaurantReservation.DTOs;

namespace RestaurantReservation.Profiles;

public class ReservationDetailProfile : Profile
{
    public ReservationDetailProfile()
    {
        CreateMap<ReservationDetail, ReservationDetailDto>();
        CreateMap<ReservationDetailDto, ReservationDetail>();
    }
}