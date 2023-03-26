namespace Api.Dtos.Match;

public class MatchDto
{
    public int Id { get; set; }
    public int MatchNo { get; set; }
    public int ManOfMatch { get; set; }
    public ICollection<MatchTeamDto>? Teams { get; set; }
    public ICollection<InningDto>? Innings { get; set; }
}