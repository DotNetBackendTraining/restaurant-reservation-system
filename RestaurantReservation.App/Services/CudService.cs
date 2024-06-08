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

    public async Task<TDto> CreateAsync(TDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        _commandRepository.Add(entity);
        await _commandRepository.SaveChangesAsync();
        return _mapper.Map<TDto>(entity);
    }

    public async Task UpdateAsync(TDto dto)
    {
        _commandRepository.Update(_mapper.Map<TEntity>(dto));
        await _commandRepository.SaveChangesAsync();
    }

    public async Task DeleteAsync(TDto dto)
    {
        _commandRepository.Delete(_mapper.Map<TEntity>(dto));
        await _commandRepository.SaveChangesAsync();
    }
}