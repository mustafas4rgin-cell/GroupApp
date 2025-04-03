using GroupApp.Core.Concrete;
using GroupApp.Core.Results;
using GroupApp.Data.Entities;
using GroupApp.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace GroupApp.Core.Services;

public class GenericService<T> : IGenericService<T> where T : EntityBase
{
    private readonly IDataRepository _repository;
    public GenericService(IDataRepository repository)
    {
        _repository = repository;
    }
    public async Task<IServiceResult<IEnumerable<T>>> GetAllAsync()
    {
        var entities =await _repository.GetAll<T>().ToListAsync();

        if (!entities.Any() || entities is null)
            return new ServiceResult<IEnumerable<T>>();

        return new ServiceResult<IEnumerable<T>>(true, "Records found", entities);
    }
    public async Task<IServiceResult<T>> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync<T>(id);

        if (entity is null)
            return new ServiceResult<T>();

        return new ServiceResult<T>(true, "Record found", entity);
    }
    public async Task<IServiceResult> AddAsync(T entity)
    {
        if (entity is null)
            return new ServiceResult(false, "Entity cannot be null");

        await _repository.AddAsync(entity);
        return new ServiceResult(true, "Record added successfully");
    }
    public async Task<IServiceResult> DeleteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync<T>(id);
        if (entity is null)
            return new ServiceResult();

        await _repository.DeleteAsync<T>(id);
        return new ServiceResult(true, "Record deleted successfully");
    }
    public async Task<IServiceResult> UpdateAsync(T entity)
    {
        if (entity is null)
            return new ServiceResult();

        await _repository.UpdateAsync(entity);
        return new ServiceResult(true, "Record updated successfully");
    }
}