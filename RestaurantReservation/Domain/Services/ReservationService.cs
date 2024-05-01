using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Domain.Interfaces.Repositories;
using RestaurantReservation.Domain.Interfaces.Services;

namespace RestaurantReservation.Domain.Services;

public class ReservationService : IReservationService
{
    private readonly IQueryRepository<Reservation> _queryRepository;

    public ReservationService(IQueryRepository<Reservation> queryRepository)
    {
        _queryRepository = queryRepository;
    }

    public IAsyncEnumerable<Reservation> GetReservationsByCustomer(int customerId)
    {
        return _queryRepository.GetAll()
            .Where(r => r.CustomerId == customerId)
            .AsAsyncEnumerable();
    }
}