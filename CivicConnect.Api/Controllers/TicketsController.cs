using CivicConnect.Api.Contracts;
using CivicConnect.Core.Interfaces;
using CivicConnect.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CivicConnect.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly ITicketService ticketService;

    public TicketsController(ITicketService ticketService)
    {
        this.ticketService = ticketService;
    }

    // GET api/tickets
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TicketResponse>>> GetAllTickets(CancellationToken cancellationToken)
    {
        var tickets = await ticketService.GetAllTicketsAsync(cancellationToken);
        return Ok(tickets.Select(TicketResponse.FromEntity));
    }

    // GET api/tickets/5
    [HttpGet("{ticketId:int}")]
    public async Task<ActionResult<TicketResponse>> GetTicketById(int ticketId, CancellationToken cancellationToken)
    {
        var ticket = await ticketService.GetTicketByIdAsync(ticketId, cancellationToken);
        return Ok(TicketResponse.FromEntity(ticket));
    }

    // POST api/tickets
    [HttpPost]
    public async Task<ActionResult<TicketResponse>> CreateTicket(CreateTicketRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateTicketCommand(
            request.Title, request.Description, request.CategoryId,
            request.SubmittedByUserId, request.IsEmergency);

        var createdTicket = await ticketService.CreateTicketAsync(command, cancellationToken);

        return CreatedAtAction(
            nameof(GetTicketById),
            new { ticketId = createdTicket.Id },
            TicketResponse.FromEntity(createdTicket));
    }

    // PATCH api/tickets/5/status
    [HttpPatch("{ticketId:int}/status")]
    public async Task<ActionResult<TicketResponse>> ChangeTicketStatus(int ticketId, ChangeTicketStatusRequest request, CancellationToken cancellationToken)
    {
        var updatedTicket = await ticketService.ChangeTicketStatusAsync(ticketId, request.NewStatus, cancellationToken);
        return Ok(TicketResponse.FromEntity(updatedTicket));
    }
}
