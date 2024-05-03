using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Application.DTOs;
using RestaurantReservation.Application.Interfaces.Services;
using RestaurantReservation.Domain.Interfaces.Repositories;
using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.Application.Services;

public class ReservationService : IReservationService
{
    private readonly IMapper _mapper;
    private readonly IQueryRepository<Reservation> _queryRepository;
    private readonly IQueryRepository<ReservationDetail> _detailQueryRepository;

    public ReservationService(
        IMapper mapper,
        IQueryRepository<Reservation> queryRepository,
        IQueryRepository<ReservationDetail> detailQueryRepository)
    {
        _mapper = mapper;
        _queryRepository = queryRepository;
        _detailQueryRepository = detailQueryRepository;
    }

    public IAsyncEnumerable<ReservationDto> GetReservationsByCustomerAsync(int customerId)
    {
        return _queryRepository.GetAll()
            .Where(r => r.CustomerId == customerId)
            .AsAsyncEnumerable()
            .Select(r => _mapper.Map<ReservationDto>(r));
    }

    public async Task<ReservationDetailDto?> GetReservationDetailAsync(int reservationId)
    {
        var reservationDetail = await _detailQueryRepository.FindAsync(reservationId);
        return _mapper.Map<ReservationDetailDto>(reservationDetail);
    }
}