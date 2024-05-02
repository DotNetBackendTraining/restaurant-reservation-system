using RestaurantReservation.Db.Interfaces.Repositories;

namespace RestaurantReservation.Db.Repositories;

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