namespace Sportics.Api.Entities.Match;

public class MatchInning
{
    public int Id { get; set; }
    public int InnningNo { get; set; }
    public int TeamId { get; set; }
    public int RunsScored { get; set; }
    public int WicketsFallen { get; set; }
    public int MatchId { get; set; }
    public Match? Match { get; set; }
    public ICollection<InningPlayerStats>? InningPlayerStats { get; set; }
}