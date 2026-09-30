using CivicConnect.Core.Entities;

namespace CivicConnect.Core.Interfaces;

// Groups all repositories and commits their changes together as ONE database transaction
public interface IUnitOfWork
{
    IRepository<Ticket> Tickets { get; }
    IRepository<User> Users { get; }
    IRepository<Category> Categories { get; }
    IRepository<AuditLog> AuditLogs { get; }

    // Saves everything staged so far; returns how many rows changed
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
