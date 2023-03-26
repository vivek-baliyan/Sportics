namespace Api.Dtos.Match;

public class MatchDto
{
    public int Id { get; set; }
    public int MatchNo { get; set; }
    public DateTime MatchDate { get; set; }
    public string Venue { get; set; } = string.Empty;
    public int Team1Id { get; set; }
    public int Team2Id { get; set; }
    public string Team1Name { get; set; } = string.Empty;
    public string Team2Name { get; set; } = string.Empty;
    public int MatchResultId { get; set; }
    public int TossId { get; set; }
    public int TournamentId { get; set; }
    public string TournamentName { get; set; } = string.Empty;
    public virtual ICollection<InningDto>? Innings { get; set; }
}