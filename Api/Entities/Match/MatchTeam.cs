namespace Api.Entities.Match;

public class MatchTeam
{
    public int Id { get; set; }
    public bool TossWon { get; set; }
    public bool MatchWon { get; set; }
    public int TeamId { get; set; }
    public Team? Team { get; set; }
    public int MatchId { get; set; }
    public Match? Match { get; set; }
}