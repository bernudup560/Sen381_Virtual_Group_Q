using CivicConnect.Core.Entities;
using CivicConnect.Core.Interfaces;
using CivicConnect.Infrastructure.Data;

namespace CivicConnect.Infrastructure.Repositories;

// Traceability: ADR-repository-unit-of-work / RTM: data integrity requirement (fill in your IDs)
public class UnitOfWork : IUnitOfWork
{
    private readonly CivicConnectDbContext dbContext;

    // Lazy = each repository is only created if somebody actually uses it
    private readonly Lazy<IRepository<Ticket>> ticketRepository;
    private readonly Lazy<IRepository<User>> userRepository;
    private readonly Lazy<IRepository<Category>> categoryRepository;
    private readonly Lazy<IRepository<AuditLog>> auditLogRepository;

    public UnitOfWork(CivicConnectDbContext dbContext)
    {
        this.dbContext = dbContext;
        ticketRepository = new Lazy<IRepository<Ticket>>(() => new Repository<Ticket>(dbContext));
        userRepository = new Lazy<IRepository<User>>(() => new Repository<User>(dbContext));
        categoryRepository = new Lazy<IRepository<Category>>(() => new Repository<Category>(dbContext));
        auditLogRepository = new Lazy<IRepository<AuditLog>>(() => new Repository<AuditLog>(dbContext));
    }

    public IRepository<Ticket> Tickets => ticketRepository.Value;
    public IRepository<User> Users => userRepository.Value;
    public IRepository<Category> Categories => categoryRepository.Value;
    public IRepository<AuditLog> AuditLogs => auditLogRepository.Value;

    // Entity Framework wraps everything staged so far in ONE transaction
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => dbContext.SaveChangesAsync(cancellationToken);
}
