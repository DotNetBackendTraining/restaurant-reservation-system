using AutoMapper;
using RestaurantReservation.Application.DTOs;
using RestaurantReservation.Application.Interfaces.Services;
using RestaurantReservation.Domain.Interfaces.Repositories;

namespace RestaurantReservation.Application.Services;

public class ReservationService : IReservationService
{
    private readonly IMapper _mapper;
    private readonly IReservationRepository _reservationRepository;

    public ReservationService(
        IMapper mapper,
        IReservationRepository reservationRepository)
    {
        _mapper = mapper;
        _reservationRepository = reservationRepository;
    }

    public async Task<IEnumerable<ReservationDto>> GetReservationsByCustomerAsync(int customerId)
    {
        var reservations = await _reservationRepository
            .GetAllReservationsByCustomerAsync(customerId)
            .ToListAsync();

        return reservations.Select(r => _mapper.Map<ReservationDto>(r));
    }

    public async Task<ReservationDetailDto?> GetReservationDetailAsync(int reservationId)
    {
        var reservationDetail = await _reservationRepository.GetReservationDetailAsync(reservationId);
        return _mapper.Map<ReservationDetailDto>(reservationDetail);
    }

    public async Task<IEnumerable<CustomerDto>> GetCustomersWithPartySizeGreaterThan(int partySize)
    {
        var customers = await _reservationRepository
            .GetCustomersWithPartySizeGreaterThan(partySize)
            .ToListAsync();

        return customers.Select(c => _mapper.Map<CustomerDto>(c));
    }
}