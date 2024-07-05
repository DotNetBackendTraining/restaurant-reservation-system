using AutoMapper;
using RestaurantReservation.App.Common;
using RestaurantReservation.App.DTOs;
using RestaurantReservation.App.Interfaces.Services;
using RestaurantReservation.Domain.Interfaces.Repositories;
using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.App.Services;

public class ReservationService : IReservationService
{
    private readonly IMapper _mapper;
    private readonly ICommandRepository<Reservation> _commandRepository;
    private readonly IReservationRepository _reservationRepository;

    public ReservationService(
        IMapper mapper,
        ICommandRepository<Reservation> commandRepository,
        IReservationRepository reservationRepository)
    {
        _mapper = mapper;
        _commandRepository = commandRepository;
        _reservationRepository = reservationRepository;
    }

    public async Task<Result<ReservationDto>> CreateAsync(ReservationDto dto)
    {
        var reservation = _mapper.Map<Reservation>(dto);
        _commandRepository.Add(reservation);
        await _commandRepository.SaveChangesAsync();
        return Result<ReservationDto>.Success(_mapper.Map<ReservationDto>(reservation));
    }

    public async Task<Result> UpdateAsync(ReservationDto dto)
    {
        var existingReservation = await _reservationRepository.GetReservationAsync(dto.ReservationId);
        if (existingReservation == null)
        {
            return Result.Failure("Reservation not found");
        }

        _mapper.Map(dto, existingReservation);
        _commandRepository.Update(existingReservation);
        await _commandRepository.SaveChangesAsync();
        return Result.Success();
    }

    public async Task<Result> DeleteAsync(ReservationDto dto)
    {
        var reservation = await _reservationRepository.GetReservationAsync(dto.ReservationId);
        if (reservation == null)
        {
            return Result.Failure("Reservation not found");
        }

        _commandRepository.Delete(reservation);
        await _commandRepository.SaveChangesAsync();
        return Result.Success();
    }

    public async Task<Result<ReservationDto>> GetReservationAsync(int reservationId)
    {
        var reservation = await _reservationRepository.GetReservationAsync(reservationId);
        return reservation == null
            ? Result<ReservationDto>.Failure("Reservation not found")
            : Result<ReservationDto>.Success(_mapper.Map<ReservationDto>(reservation));
    }

    public async Task<Result<IEnumerable<ReservationDto>>> GetReservationsByCustomerAsync(int customerId)
    {
        var reservations = await _reservationRepository
            .GetAllReservationsByCustomerAsync(customerId)
            .ToListAsync();

        var reservationDtos = reservations.Select(r => _mapper.Map<ReservationDto>(r));
        return Result<IEnumerable<ReservationDto>>.Success(reservationDtos);
    }

    public async Task<Result<ReservationDetailDto>> GetReservationDetailAsync(int reservationId)
    {
        var reservationDetail = await _reservationRepository.GetReservationDetailAsync(reservationId);
        return reservationDetail == null
            ? Result<ReservationDetailDto>.Failure("Reservation detail not found")
            : Result<ReservationDetailDto>.Success(_mapper.Map<ReservationDetailDto>(reservationDetail));
    }
}