namespace Api.Entities.Match;

public class Toss
{
    public int Id { get; set; }
    public int MatchId { get; set; }
    public int WinningTeamId { get; set; }
    public int TossDecisionId { get; set; }
    public virtual Match? Match { get; set; }
    public virtual Team? WinningTeam { get; set; }
    public virtual TossDecision? TossDecision { get; set; }
}