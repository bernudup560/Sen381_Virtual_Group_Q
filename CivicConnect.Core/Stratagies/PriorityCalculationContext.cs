using CivicConnect.Core.Entities;
using CivicConnect.Core.Exceptions;

namespace CivicConnect.Core.Strategies;

// Picks the right strategy so the service never needs to know which strategies exist
public class PriorityCalculationContext
{
    private readonly IReadOnlyList<IPriorityCalculationStrategy> strategiesInEvaluationOrder;

    // Dependency injection supplies every registered strategy automatically
    public PriorityCalculationContext(IEnumerable<IPriorityCalculationStrategy> strategies)
    {
        strategiesInEvaluationOrder = strategies.OrderBy(strategy => strategy.EvaluationOrder).ToList();
    }

    public TicketPriority CalculatePriority(Ticket ticket, Category category)
    {
        // First strategy (lowest order) that says "this is mine" wins
        var matchingStrategy = strategiesInEvaluationOrder
            .FirstOrDefault(strategy => strategy.IsApplicableTo(ticket));

        if (matchingStrategy is null)
            throw new DomainRuleViolationException("No priority strategy is registered for this ticket.");

        return matchingStrategy.CalculatePriority(ticket, category);
    }
}
