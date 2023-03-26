namespace Api.Dtos;

public class TeamDto
{
    public int Id { get; set; }
    public string TeamName { get; set; } = string.Empty;
    public string HomeCity { get; set; } = string.Empty;
    public string Coach { get; set; } = string.Empty;
    public virtual ICollection<PlayerDto>? Players { get; set; }
}