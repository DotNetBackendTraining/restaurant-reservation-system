using RestaurantReservation.Domain.Interfaces.Repositories;
using RestaurantReservation.Interfaces.Services;

namespace RestaurantReservation.Services;

public class CudService<TEntity> : ICudService<TEntity>
    where TEntity : class
{
    private readonly ICommandRepository<TEntity> _commandRepository;

    public CudService(ICommandRepository<TEntity> commandRepository)
    {
        _commandRepository = commandRepository;
    }

    public async Task CreateAsync(TEntity entity)
    {
        _commandRepository.Add(entity);
        await _commandRepository.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _commandRepository.Update(entity);
        await _commandRepository.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _commandRepository.Add(entity);
        await _commandRepository.SaveChangesAsync();
    }
}