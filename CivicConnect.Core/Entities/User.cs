namespace CivicConnect.Core.Entities;

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = "Citizen";

    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
