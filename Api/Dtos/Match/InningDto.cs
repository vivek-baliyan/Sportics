namespace Api.Dtos.Match;
public class InningDto
{
    public int Id { get; set; }
    public int MatchId { get; set; }
    public int InningsNumber { get; set; }
    public int BattingTeamId { get; set; }
    public virtual ICollection<ScorecardDto>? Scorecard { get; set; }
}