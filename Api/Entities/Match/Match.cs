namespace Api.Entities.Match;

public class Match
{
    public int Id { get; set; }
    public int TournamentId { get; set; }
    public int MatchNo { get; set; }
    public DateTime MatchDate { get; set; }
    public string Venue { get; set; } = string.Empty;
    public int Team1Id { get; set; }
    public int Team2Id { get; set; }
    public virtual Team? Team1 { get; set; }
    public virtual Team? Team2 { get; set; }
    public virtual MatchResult? Result { get; set; }
    public virtual Toss? Toss { get; set; }
    public virtual Tournament.Tournament? Tournament { get; set; }
    public virtual ICollection<Inning>? Innings { get; set; }
}