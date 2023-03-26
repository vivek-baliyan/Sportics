namespace Api.Dtos.Match;
public class ScorecardDto
{
    public int Id { get; set; }
    public int MatchId { get; set; }
    public int PlayerId { get; set; }
    public int Runs { get; set; }
    public int BallsFaced { get; set; }
    public int Fours { get; set; }
    public int Sixes { get; set; }
    public float OversBowled { get; set; }
    public int Maidens { get; set; }
    public int Wickets { get; set; }
    public int RunsConceded { get; set; }
}