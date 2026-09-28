using CivicConnect.Core.Interfaces;
using CivicConnect.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CivicConnect.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbSet<T> _set;

    public Repository(CivicConnectDbContext context)
    {
        _set = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id) => await _set.FindAsync(id);

    public async Task<IEnumerable<T>> GetAllAsync() => await _set.ToListAsync();

    public async Task AddAsync(T entity) => await _set.AddAsync(entity);

    public void Update(T entity) => _set.Update(entity);

    public void Remove(T entity) => _set.Remove(entity);
}
