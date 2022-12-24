namespace Sportics.Api.Dtos;

public class PlayerDto
{
    public int Id { get; set; }
    public string? PlayerName { get; set; }
    public int TeamId { get; set; }
    public string? TeamName { get; set; }
}