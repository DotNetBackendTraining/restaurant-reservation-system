using RestaurantReservation.Db.Interfaces.Repositories;

namespace RestaurantReservation.Db.Repositories;

public class CommandRepository<TEntity> : ICommandRepository<TEntity>
    where TEntity : class
{
    private readonly RestaurantReservationDbContext _context;

    public CommandRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public void Add(TEntity entity) => _context.Add(entity);

    public void Update(TEntity entity) => _context.Update(entity);

    public void Delete(TEntity entity) => _context.Remove(entity);

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
}