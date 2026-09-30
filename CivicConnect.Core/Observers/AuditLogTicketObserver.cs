using CivicConnect.Core.Entities;
using CivicConnect.Core.Interfaces;

namespace CivicConnect.Core.Observers;

// Observer pattern in action. Traceability: ADR-observer / RTM: audit requirement (fill in your IDs)
public class AuditLogTicketObserver : ITicketObserver
{
    private readonly IUnitOfWork unitOfWork;

    public AuditLogTicketObserver(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public Task OnTicketCreatedAsync(Ticket ticket, CancellationToken cancellationToken = default)
    {
        // Only STAGES the row; the service commits it together with the ticket
        var auditEntry = new AuditLog(
            ticket,
            "TicketCreated",
            $"Ticket '{ticket.Title}' created with priority {ticket.Priority}.");

        return unitOfWork.AuditLogs.AddAsync(auditEntry, cancellationToken);
    }

    public Task OnTicketStatusChangedAsync(Ticket ticket, TicketStatus previousStatus, CancellationToken cancellationToken = default)
    {
        var auditEntry = new AuditLog(
            ticket,
            "TicketStatusChanged",
            $"Status changed from {previousStatus} to {ticket.Status}.");

        return unitOfWork.AuditLogs.AddAsync(auditEntry, cancellationToken);
    }
}
