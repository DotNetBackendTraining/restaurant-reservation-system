namespace RestaurantReservation.Presentation.Interfaces;

public interface ICudController<in TEntity>
{
    Task Create(TEntity entity);
    Task Update(TEntity entity);
    Task Delete(TEntity entity);
}