namespace RestaurantReservation.Domain.Interfaces.Repositories;

public interface ICommandRepository<in TEntity>
    where TEntity : class
{
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task<int> SaveChangesAsync();
}