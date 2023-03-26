namespace Api.Entities.Tournament;

public class Tournament
{
    public int Id { get; set; }
    public string TournamentName { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ICollection<TeamStanding>? TeamStandings { get; set; }
    public ICollection<Match.Match>? Matches { get; set; }
}