using CivicConnect.Core.Entities;

namespace CivicConnect.Core.Strategies;

// Traceability: ADR-strategy / RTM: emergency escalation requirement (fill in your IDs)
public class EmergencyPriorityStrategy : IPriorityCalculationStrategy
{
    public int EvaluationOrder => 10;

    // Only tickets flagged as emergencies are handled here
    public bool IsApplicableTo(Ticket ticket) => ticket.IsEmergency;

    // Emergencies are always Critical, regardless of category
    public TicketPriority CalculatePriority(Ticket ticket, Category category) => TicketPriority.Critical;
}
