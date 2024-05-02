namespace RestaurantReservation.Db.Interfaces.Repositories;

public interface IQueryRepository<TEntity>
    where TEntity : class
{
    IQueryable<TEntity> GetAll();
    Task<TEntity?> FindAsync(object id);
}