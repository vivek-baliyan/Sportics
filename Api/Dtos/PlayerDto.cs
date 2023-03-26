using Api.Dtos.Match;

namespace Api.Dtos;

public class PlayerDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Nationality { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public int TeamId { get; set; }
    public string TeamName { get; set; } = string.Empty;
    public virtual ICollection<MatchPlayerStatisticDto>? MatchPlayerStatistics { get; set; }
}