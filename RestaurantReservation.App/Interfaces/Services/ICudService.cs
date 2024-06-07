namespace RestaurantReservation.App.Interfaces.Services;

public interface ICudService<in TDto>
    where TDto : class
{
    Task CreateAsync(TDto entity);
    Task UpdateAsync(TDto entity);
    Task DeleteAsync(TDto entity);
}