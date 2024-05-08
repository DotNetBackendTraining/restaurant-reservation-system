using AutoMapper;
using RestaurantReservation.Application.DTOs;
using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.Application.Profiles;

public class ReservationDetailProfile : Profile
{
    public ReservationDetailProfile()
    {
        CreateMap<ReservationDetail, ReservationDetailDto>();
        CreateMap<ReservationDetailDto, ReservationDetail>();
    }
}