using RestaurantReservation.Db;
using RestaurantReservation.Domain.Interfaces.Repositories;

namespace RestaurantReservation.Domain.Repositories;

public class QueryRepository<TEntity> : IQueryRepository<TEntity>
    where TEntity : class
{
    private readonly RestaurantReservationDbContext _context;

    public QueryRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public IQueryable<TEntity> GetAll() => _context.Set<TEntity>();

    public async Task<TEntity?> FindAsync(object id) => await _context.FindAsync<TEntity>(id);
}