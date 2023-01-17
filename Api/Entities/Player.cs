namespace Sportics.Api.Entities;

public class Player
{
    public int Id { get; set; }
    public string? PlayerName { get; set; }
    public int TeamId { get; set; }
    public Team? Team { get; set; }
}