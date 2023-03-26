namespace Api.Entities.Tournament;

public class Tournament
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ICollection<Team>? Teams { get; set; }
    public ICollection<Match.Match>? Matches { get; set; }
}