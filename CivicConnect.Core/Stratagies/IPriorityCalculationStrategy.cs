using CivicConnect.Core.Entities;

namespace CivicConnect.Core.Strategies;

// One way of deciding a ticket's priority. New rules = new class, not edited if/else chains.
public interface IPriorityCalculationStrategy
{
    // Lower number is checked first, so specific rules beat general ones
    int EvaluationOrder { get; }

    // Does this strategy want to handle the given ticket?
    bool IsApplicableTo(Ticket ticket);

    // Works out the priority using the ticket and its category
    TicketPriority CalculatePriority(Ticket ticket, Category category);
}
