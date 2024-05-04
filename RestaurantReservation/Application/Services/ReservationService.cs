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

    public IAsyncEnumerable<ReservationDto> GetReservationsByCustomerAsync(int customerId)
    {
        return _reservationRepository.GetAllReservationsByCustomerAsync(customerId)
            .Select(r => _mapper.Map<ReservationDto>(r));
    }

    public async Task<ReservationDetailDto?> GetReservationDetailAsync(int reservationId)
    {
        var reservationDetail = await _reservationRepository.GetReservationDetailAsync(reservationId);
        return _mapper.Map<ReservationDetailDto>(reservationDetail);
    }

    public IAsyncEnumerable<CustomerDto> GetCustomersWithPartySizeGreaterThan(int partySize)
    {
        return _reservationRepository.GetCustomersWithPartySizeGreaterThan(partySize)
            .Select(c => _mapper.Map<CustomerDto>(c));
    }
}