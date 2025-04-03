using GroupApp.Core.Results;
using GroupApp.Data.Entities;

namespace GroupApp.Core.Concrete;

public interface IGenericService<T> where T : EntityBase
{
    Task<IServiceResult<T>> GetByIdAsync(int id);
    Task<IServiceResult<IEnumerable<T>>> GetAllAsync();
    Task<IServiceResult> AddAsync(T entity);
    Task<IServiceResult> UpdateAsync(T entity);
    Task<IServiceResult> DeleteAsync(int id);
}