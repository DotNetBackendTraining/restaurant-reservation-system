using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Application.DTOs;
using RestaurantReservation.Application.Interfaces.Services;
using RestaurantReservation.Db.Interfaces.Repositories;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Application.Services;

public class ReservationService : IReservationService
{
    private readonly IQueryRepository<Reservation> _queryRepository;
    private readonly IMapper _mapper;

    public ReservationService(
        IQueryRepository<Reservation> queryRepository,
        IMapper mapper)
    {
        _queryRepository = queryRepository;
        _mapper = mapper;
    }

    public IAsyncEnumerable<ReservationDto> GetReservationsByCustomerAsync(int customerId)
    {
        return _queryRepository.GetAll()
            .Where(r => r.CustomerId == customerId)
            .AsAsyncEnumerable()
            .Select(r => _mapper.Map<ReservationDto>(r));
    }
}