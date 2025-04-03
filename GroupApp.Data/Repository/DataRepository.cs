using GroupApp.Data.Context;
using GroupApp.Data.Entities;

namespace GroupApp.Data.Repository;

public class DataRepository : IDataRepository
{
    private readonly AppDbContext _context;

    public DataRepository(AppDbContext context)
    {
        _context = context;
    }
    public IQueryable<T> GetAll<T>() where T : EntityBase
    {
        return _context.Set<T>().AsQueryable();
    }
    public async Task<T?> GetByIdAsync<T>(int id) where T : EntityBase
    {
        return await _context.Set<T>().FindAsync(id);
    }
    public async Task<T> AddAsync<T>(T entity) where T : EntityBase
    {
        entity.Id = default;
        entity.CreatedAt = DateTime.UtcNow;

        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }
    public async Task<T> UpdateAsync<T>(T entity) where T : EntityBase
    {
        if (entity.Id == default)
            return null;

        var dbEntity = await GetByIdAsync<T>(entity.Id);

        if (dbEntity == null)
            return null;

        entity.CreatedAt = dbEntity.CreatedAt;

        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();

        return entity;
    }
    public async Task DeleteAsync<T>(int id) where T : EntityBase
    {
        var entity = await GetByIdAsync<T>(id);

        if (entity == null)
            return;

        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}