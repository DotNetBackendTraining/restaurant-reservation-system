namespace RestaurantReservation.App.Interfaces.Services;

public interface ICudService<TDto>
    where TDto : class
{
    /// <summary>
    /// Converts the dto to entity and inserts it into the database.
    /// Returns the newly created object mapped back to dto.
    /// </summary>
    /// <param name="dto">DTO of the entity to be inserted</param>
    /// <returns>DTO of the new entity</returns>
    Task<TDto> CreateAsync(TDto dto);

    Task UpdateAsync(TDto dto);
    Task DeleteAsync(TDto dto);
}