using CivicConnect.Core.Entities;

namespace CivicConnect.Core.Observers;

// Anyone who wants to react to ticket events (audit, email, SMS...) implements this
public interface ITicketObserver
{
    Task OnTicketCreatedAsync(Ticket ticket, CancellationToken cancellationToken = default);
    Task OnTicketStatusChangedAsync(Ticket ticket, TicketStatus previousStatus, CancellationToken cancellationToken = default);
}
