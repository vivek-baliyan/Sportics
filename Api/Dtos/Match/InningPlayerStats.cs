namespace Api.Dtos.Match;

public class InningPlayerStatsDto
{
    public int Id { get; set; }
    public int BattingPosition { get; set; }
    public int RunsScored { get; set; }
    public int BallsPlayed { get; set; }
    public int CacthesTaken { get; set; }
    public int WicketsTaken { get; set; }
    public float OversBowled { get; set; }
    public int MatchInningId { get; set; }
}