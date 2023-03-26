namespace Api.Entities.Match;

public class Inning
{
    public int Id { get; set; }
    public int MatchId { get; set; }
    public int InningsNumber { get; set; }
    public int BattingTeamId { get; set; }
    public virtual Match? Match { get; set; }
    public virtual Team? BattingTeam { get; set; }
    public virtual ICollection<Scorecard>? Scorecard { get; set; }
}