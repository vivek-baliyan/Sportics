import { MatchInning } from './matchInning';
import { MatchTeam } from './matchTeam.';

export interface Match {
  id: number;
  matchNo: number;
  manOfMatch: number;
  teams: MatchTeam[];
  innings: MatchInning[];
}
