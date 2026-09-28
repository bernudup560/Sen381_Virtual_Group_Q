using System.Collections.Concurrent;
using CivicConnect.Core.Interfaces;
using CivicConnect.Infrastructure.Data;

namespace CivicConnect.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly CivicConnectDbContext _context;
    private readonly ConcurrentDictionary<Type, object> _repositories = new();

    public UnitOfWork(CivicConnectDbContext context)
    {
        _context = context;
    }

    public IRepository<T> Repository<T>() where T : class =>
        (IRepository<T>)_repositories.GetOrAdd(typeof(T), _ => new Repository<T>(_context));

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        _context.SaveChangesAsync(cancellationToken);

    public void Dispose() => _context.Dispose();
}
