namespace Api.Dtos.Match;

public class MatchTeamDto
{
    public int Id { get; set; }
    public bool TossWon { get; set; }
    public bool MatchWon { get; set; }
    public int TeamId { get; set; }
    public string TeamName { get; set; } = string.Empty;
}