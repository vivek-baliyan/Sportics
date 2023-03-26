using Api.Enum;

namespace Api.Dtos.Match;
public class TossDto
{
    public int Id { get; set; }
    public int MatchId { get; set; }
    public int WinningTeamId { get; set; }
    public TossDecision TossDecision { get; set; }
}