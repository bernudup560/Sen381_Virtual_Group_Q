using CivicConnect.Core.Entities;

namespace CivicConnect.Core.Strategies;

// The fallback rule used when no more specific strategy applies
public class StandardPriorityStrategy : IPriorityCalculationStrategy
{
    // Runs last so specific strategies get the first chance
    public int EvaluationOrder => 100;

    public bool IsApplicableTo(Ticket ticket) => true;

    // Translates the category's urgency score (1-10) into a priority band
    public TicketPriority CalculatePriority(Ticket ticket, Category category)
    {
        if (category.BaseUrgencyScore >= 8) return TicketPriority.High;
        if (category.BaseUrgencyScore >= 5) return TicketPriority.Medium;
        return TicketPriority.Low;
    }
}
