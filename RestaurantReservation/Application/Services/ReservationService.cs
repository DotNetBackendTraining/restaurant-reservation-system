using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Application.Interfaces.Services;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Domain.Interfaces.Repositories;

namespace RestaurantReservation.Application.Services;

public class ReservationService : IReservationService
{
    private readonly IQueryRepository<Reservation> _queryRepository;

    public ReservationService(IQueryRepository<Reservation> queryRepository)
    {
        _queryRepository = queryRepository;
    }

    public IAsyncEnumerable<Reservation> GetReservationsByCustomerAsync(int customerId)
    {
        return _queryRepository.GetAll()
            .Where(r => r.CustomerId == customerId)
            .AsAsyncEnumerable();
    }
}