namespace Api.Dtos.Match;

public class MatchInningDto
{
    public int Id { get; set; }
    public int InnningNo { get; set; }
    public int TeamId { get; set; }
    public int RunsScored { get; set; }
    public int WicketsFallen { get; set; }
    public int MatchId { get; set; }
    public MatchDto? Match { get; set; }
    public ICollection<InningPlayerStatsDto>? InningPlayerStats { get; set; }
}