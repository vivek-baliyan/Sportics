using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Entities.Match
{
    public class MatchResult
    {
        public int Id { get; set; }
        public int? WinningTeamId { get; set; }
        public int? WinningMarginRuns { get; set; }
        public int? WinningMarginWickets { get; set; }
        public virtual Team? WinningTeam { get; set; }
    }
}