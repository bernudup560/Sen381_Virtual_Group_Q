using CivicConnect.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CivicConnect.Infrastructure.Data;

public class CivicConnectDbContext : DbContext
{
    public CivicConnectDbContext(DbContextOptions<CivicConnectDbContext> options)
        : base(options)
    {
    }

    public DbSet<Ticket> Tickets => Set<Ticket>();
    public DbSet<User> Users => Set<User>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.CreatedByUser)
            .WithMany(u => u.Tickets)
            .HasForeignKey(t => t.CreatedByUserId);

        base.OnModelCreating(modelBuilder);
    }
}
