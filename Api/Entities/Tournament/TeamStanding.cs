namespace Api.Entities.Tournament;
public class TeamStanding
{
    public int Id { get; set; }
    public int TournamentId { get; set; }
    public int TeamId { get; set; }
    public int MatchesPlayed { get; set; }
    public int MatchesWon { get; set; }
    public int MatchesLost { get; set; }
    public int MatchesTied { get; set; }
    public int NoResults { get; set; }
    public int Points { get; set; }
    public virtual Tournament? Tournament { get; set; }
    public virtual Team? Team { get; set; }
}