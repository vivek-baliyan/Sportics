namespace Sportics.Api.Entities.Match;

public class Match
{
    public int Id { get; set; }
    public int MatchNo { get; set; }
    public int ManOfMatch { get; set; }
    public ICollection<MatchTeam>? Teams { get; set; }
    public ICollection<MatchInning>? Innings { get; set; }
}