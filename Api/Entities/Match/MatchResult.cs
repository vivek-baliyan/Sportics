namespace Api.Entities.Match
{
    public class MatchResult
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int WinningTeamId { get; set; }
        public int WinningTeamInningId { get; set; }
        public int WinningMarginRuns { get; set; }
        public int WinningMarginWickets { get; set; }
        public virtual Match? Match { get; set; }
        public virtual Team? WinningTeam { get; set; }
        public virtual Inning? WinningTeamInning { get; set; }
    }
}