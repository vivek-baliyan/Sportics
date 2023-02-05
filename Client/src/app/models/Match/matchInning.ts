import { InningPlayerStats } from './inningPlayerStats';

export interface MatchInning {
  id: number;
  innningNo: number;
  teamId: number;
  runsScored: number;
  wicketsFallen: number;
  matchId: number;
  inningPlayerStats: InningPlayerStats[];
}
