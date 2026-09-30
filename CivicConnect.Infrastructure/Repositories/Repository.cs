using System.Linq.Expressions;
using CivicConnect.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CivicConnect.Infrastructure.Repositories;

// One reusable implementation that works for ANY entity type
public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DbSet<TEntity> entitySet;

    public Repository(DbContext dbContext)
    {
        entitySet = dbContext.Set<TEntity>();
    }

    public async Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        => await entitySet.FindAsync(new object[] { id }, cancellationToken);

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        => await entitySet.AsNoTracking().ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
        => await entitySet.AsNoTracking().Where(filter).ToListAsync(cancellationToken);

    // Stages the entity; nothing hits the database until SaveChangesAsync
    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        => await entitySet.AddAsync(entity, cancellationToken);

    public void Update(TEntity entity) => entitySet.Update(entity);

    public void Remove(TEntity entity) => entitySet.Remove(entity);
}
