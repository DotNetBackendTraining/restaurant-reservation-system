using AutoMapper;
using RestaurantReservation.App.DTOs;
using RestaurantReservation.App.Interfaces.Services;
using RestaurantReservation.Domain.Interfaces.Repositories;

namespace RestaurantReservation.App.Services;

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

    public async Task<ReservationDto?> GetReservationAsync(int reservationId)
    {
        var reservation = await _reservationRepository.GetReservationAsync(reservationId);
        return _mapper.Map<ReservationDto>(reservation);
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
        return reservationDetail is null
            ? null
            : _mapper.Map<ReservationDetailDto>(reservationDetail);
    }

    public async Task<IEnumerable<CustomerDto>> GetCustomersWithPartySizeGreaterThan(int partySize)
    {
        var customers = await _reservationRepository
            .GetCustomersWithPartySizeGreaterThan(partySize)
            .ToListAsync();

        return customers.Select(c => _mapper.Map<CustomerDto>(c));
    }
}