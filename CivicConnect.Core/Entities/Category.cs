using CivicConnect.Core.Exceptions;

namespace CivicConnect.Core.Entities;

// A type of civic problem, e.g. "Water and sanitation"
public class Category
{
    private Category() { }

    public Category(string name, string description, int baseUrgencyScore)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainRuleViolationException("A category must have a name.");
        if (baseUrgencyScore < 1 || baseUrgencyScore > 10)
            throw new DomainRuleViolationException("Base urgency score must be between 1 and 10.");

        Name = name.Trim();
        Description = description?.Trim() ?? string.Empty;
        BaseUrgencyScore = baseUrgencyScore;
    }

    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;

    // 1 (minor) to 10 (severe): how urgent problems in this category normally are
    public int BaseUrgencyScore { get; private set; }

    public ICollection<Ticket> Tickets { get; private set; } = new List<Ticket>();
}
