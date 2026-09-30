namespace CivicConnect.Core.Entities;

// One row per important thing that happened to a ticket
public class AuditLog
{
    private AuditLog() { }

    public AuditLog(Ticket ticket, string actionName, string details)
    {
        // We hold the Ticket object (not just its id) because a brand-new ticket has no id until saved.
        // Entity Framework fills in TicketId automatically when both are saved together.
        Ticket = ticket ?? throw new ArgumentNullException(nameof(ticket));
        ActionName = actionName;
        Details = details;
        PerformedAtUtc = DateTime.UtcNow;
    }

    public int Id { get; private set; }
    public int? TicketId { get; private set; }
    public Ticket? Ticket { get; private set; }
    public string ActionName { get; private set; } = string.Empty;
    public string Details { get; private set; } = string.Empty;
    public DateTime PerformedAtUtc { get; private set; }
}
