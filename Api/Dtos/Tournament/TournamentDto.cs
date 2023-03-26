namespace Api.Dtos.Tournament;
public class TournamentDto
{
    public int Id { get; set; }
    public string TournamentName { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}