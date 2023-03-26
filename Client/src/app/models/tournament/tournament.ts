import { Match } from '../match/match';

export interface Tournament {
  id: number;
  tournamentName: string;
  startDate: Date;
  endDate: Date;
  matches: Match[];
}
