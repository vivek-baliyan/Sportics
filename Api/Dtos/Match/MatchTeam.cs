namespace Sportics.Api.Dtos.Match;

public class MatchTeamDto
{
    public int Id { get; set; }
    public bool TossWon { get; set; }
    public bool MatchWon { get; set; }
    public int TeamId { get; set; }
    public TeamDto? Team { get; set; }
    public int MatchId { get; set; }
    public MatchDto? Match { get; set; }
}