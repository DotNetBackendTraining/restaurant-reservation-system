using AutoMapper;
using RestaurantReservation.App.Interfaces.Services;
using RestaurantReservation.Domain.Interfaces.Repositories;

namespace RestaurantReservation.App.Services;

/// <summary>
/// Maps <see cref="TDto"/> to <see cref="TEntity"/> before performing operations.
/// </summary>
public class CudService<TDto, TEntity> : ICudService<TDto>
    where TDto : class
    where TEntity : class
{
    private readonly IMapper _mapper;
    private readonly ICommandRepository<TEntity> _commandRepository;

    public CudService(
        IMapper mapper,
        ICommandRepository<TEntity> commandRepository)
    {
        _mapper = mapper;
        _commandRepository = commandRepository;
    }

    public async Task CreateAsync(TDto entity)
    {
        _commandRepository.Add(_mapper.Map<TEntity>(entity));
        await _commandRepository.SaveChangesAsync();
    }

    public async Task UpdateAsync(TDto entity)
    {
        _commandRepository.Update(_mapper.Map<TEntity>(entity));
        await _commandRepository.SaveChangesAsync();
    }

    public async Task DeleteAsync(TDto entity)
    {
        _commandRepository.Delete(_mapper.Map<TEntity>(entity));
        await _commandRepository.SaveChangesAsync();
    }
}