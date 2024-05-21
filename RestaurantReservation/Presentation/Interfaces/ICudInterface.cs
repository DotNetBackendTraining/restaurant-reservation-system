namespace RestaurantReservation.Presentation.Interfaces;

public interface ICudInterface<in TEntity>
{
    Task Create(TEntity entity);
    Task Update(TEntity entity);
    Task Delete(TEntity entity);
}