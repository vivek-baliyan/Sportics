namespace Api.Dtos.Match;

public class MatchResultDto
{
    public int Id { get; set; }
    public int WinningTeamId { get; set; }
    public int WinningTeamInningId { get; set; }
    public int WinningMarginRuns { get; set; }
    public int WinningMarginWickets { get; set; }
}