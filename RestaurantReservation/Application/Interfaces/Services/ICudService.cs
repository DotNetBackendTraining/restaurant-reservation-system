namespace RestaurantReservation.Application.Interfaces.Services;

public interface ICudService<in TEntity>
    where TEntity : class
{
    Task CreateAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
}