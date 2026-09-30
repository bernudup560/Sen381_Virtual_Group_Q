using System.ComponentModel.DataAnnotations;
using CivicConnect.Core.Entities;

namespace CivicConnect.Api.Contracts;

// What a client must send to create a ticket
public class CreateTicketRequest
{
    [Required, StringLength(200, MinimumLength = 5)]
    public string Title { get; set; } = string.Empty;

    [Required, StringLength(2000, MinimumLength = 10)]
    public string Description { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int CategoryId { get; set; }

    [Range(1, int.MaxValue)]
    public int SubmittedByUserId { get; set; }

    public bool IsEmergency { get; set; }
}

// What a client must send to move a ticket to a new status
public class ChangeTicketStatusRequest
{
    [EnumDataType(typeof(TicketStatus))]
    public TicketStatus NewStatus { get; set; }
}

// What the API sends back (never expose the raw entity)
public class TicketResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public int SubmittedByUserId { get; set; }
    public bool IsEmergency { get; set; }
    public TicketStatus Status { get; set; }
    public TicketPriority Priority { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public DateTime LastUpdatedAtUtc { get; set; }

    // Converts a Ticket entity into the shape the outside world sees
    public static TicketResponse FromEntity(Ticket ticket) => new()
    {
        Id = ticket.Id,
        Title = ticket.Title,
        Description = ticket.Description,
        CategoryId = ticket.CategoryId,
        SubmittedByUserId = ticket.SubmittedByUserId,
        IsEmergency = ticket.IsEmergency,
        Status = ticket.Status,
        Priority = ticket.Priority,
        CreatedAtUtc = ticket.CreatedAtUtc,
        LastUpdatedAtUtc = ticket.LastUpdatedAtUtc
    };
}
