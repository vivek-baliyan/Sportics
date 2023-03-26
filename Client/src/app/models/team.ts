import { Player } from './player';

export interface Team {
  id: number;
  teamName: string;
  homeCity: string;
  coach: string;
  players: Player[];
}
