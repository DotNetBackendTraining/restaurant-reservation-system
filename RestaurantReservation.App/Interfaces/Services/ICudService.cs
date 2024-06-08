namespace RestaurantReservation.App.Interfaces.Services;

public interface ICudService<TDto>
    where TDto : class
{
    Task<TDto> CreateAsync(TDto dto);
    Task UpdateAsync(TDto dto);
    Task DeleteAsync(TDto dto);
}