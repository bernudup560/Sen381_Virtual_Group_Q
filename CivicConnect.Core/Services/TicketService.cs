using CivicConnect.Core.Entities;
using CivicConnect.Core.Exceptions;
using CivicConnect.Core.Interfaces;
using CivicConnect.Core.Observers;
using CivicConnect.Core.Strategies;

namespace CivicConnect.Core.Services;

// Plain data carrier: keeps Core independent from the Api's request classes
public record CreateTicketCommand(
    string Title,
    string Description,
    int CategoryId,
    int SubmittedByUserId,
    bool IsEmergency);

// The use-case layer: coordinates entities, strategies, observers and the database
public class TicketService : ITicketService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly PriorityCalculationContext priorityCalculationContext;
    private readonly IEnumerable<ITicketObserver> ticketObservers;

    public TicketService(
        IUnitOfWork unitOfWork,
        PriorityCalculationContext priorityCalculationContext,
        IEnumerable<ITicketObserver> ticketObservers)
    {
        this.unitOfWork = unitOfWork;
        this.priorityCalculationContext = priorityCalculationContext;
        this.ticketObservers = ticketObservers;
    }

    public async Task<Ticket> CreateTicketAsync(CreateTicketCommand command, CancellationToken cancellationToken = default)
    {
        // 1. Make sure the referenced category and user really exist
        var category = await unitOfWork.Categories.GetByIdAsync(command.CategoryId, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Category), command.CategoryId);
        _ = await unitOfWork.Users.GetByIdAsync(command.SubmittedByUserId, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(User), command.SubmittedByUserId);

        // 2. Build the ticket (the entity validates itself)
        var ticket = new Ticket(
            command.Title, command.Description, command.CategoryId,
            command.SubmittedByUserId, command.IsEmergency);

        // 3. Let the strategy decide the priority
        ticket.AssignPriority(priorityCalculationContext.CalculatePriority(ticket, category));

        // 4. Stage the ticket, then tell every observer it happened
        await unitOfWork.Tickets.AddAsync(ticket, cancellationToken);
        foreach (var observer in ticketObservers)
            await observer.OnTicketCreatedAsync(ticket, cancellationToken);

        // 5. One commit: ticket + audit rows succeed or fail together
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return ticket;
    }

    public async Task<Ticket> ChangeTicketStatusAsync(int ticketId, TicketStatus newStatus, CancellationToken cancellationToken = default)
    {
        var ticket = await GetTicketByIdAsync(ticketId, cancellationToken);
        var previousStatus = ticket.Status;

        // The entity enforces the allowed transitions
        ticket.TransitionTo(newStatus);
        unitOfWork.Tickets.Update(ticket);

        foreach (var observer in ticketObservers)
            await observer.OnTicketStatusChangedAsync(ticket, previousStatus, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return ticket;
    }

    public async Task<Ticket> GetTicketByIdAsync(int ticketId, CancellationToken cancellationToken = default)
    {
        return await unitOfWork.Tickets.GetByIdAsync(ticketId, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Ticket), ticketId);
    }

    public Task<IReadOnlyList<Ticket>> GetAllTicketsAsync(CancellationToken cancellationToken = default)
    {
        return unitOfWork.Tickets.GetAllAsync(cancellationToken);
    }
}
