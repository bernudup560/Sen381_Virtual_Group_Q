using CivicConnect.Core.Exceptions;

namespace CivicConnect.Core.Entities;

// The kinds of people who use CivicConnect
public enum UserRole
{
    Citizen = 0,
    MunicipalStaff = 1,
    Administrator = 2
}

public class User
{
    // Parameterless constructor is only for Entity Framework to build objects from the database
    private User() { }

    public User(string fullName, string emailAddress, UserRole role)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new DomainRuleViolationException("A user must have a full name.");
        if (string.IsNullOrWhiteSpace(emailAddress) || !emailAddress.Contains('@'))
            throw new DomainRuleViolationException("A user must have a valid email address.");

        FullName = fullName.Trim();
        EmailAddress = emailAddress.Trim().ToLowerInvariant();
        Role = role;
        RegisteredAtUtc = DateTime.UtcNow;
    }

    public int Id { get; private set; }
    public string FullName { get; private set; } = string.Empty;
    public string EmailAddress { get; private set; } = string.Empty;
    public UserRole Role { get; private set; }
    public DateTime RegisteredAtUtc { get; private set; }

    // All tickets this user has reported
    public ICollection<Ticket> SubmittedTickets { get; private set; } = new List<Ticket>();
}
