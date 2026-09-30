using CivicConnect.Core.Entities;
using CivicConnect.Core.Services;

namespace CivicConnect.Core.Interfaces;

// What the Api layer is allowed to ask the business logic to do
public interface ITicketService
{
    Task<Ticket> CreateTicketAsync(CreateTicketCommand command, CancellationToken cancellationToken = default);
    Task<Ticket> ChangeTicketStatusAsync(int ticketId, TicketStatus newStatus, CancellationToken cancellationToken = default);
    Task<Ticket> GetTicketByIdAsync(int ticketId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Ticket>> GetAllTicketsAsync(CancellationToken cancellationToken = default);
}
