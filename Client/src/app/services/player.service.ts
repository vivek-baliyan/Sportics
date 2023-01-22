import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Player } from '../models/player';

@Injectable({
  providedIn: 'root',
})
export class PlayerService {
  private baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) {}

  getPlayer(id: number) {
    return this.http.get(this.baseUrl + 'player/' + id);
  }

  getPlayers() {
    return this.http.get(this.baseUrl + 'player');
  }

  createPlayer(player: Player) {
    return this.http.post(this.baseUrl + 'player', player);
  }

  updatePlayer(player: Player) {
    return this.http.put(this.baseUrl + 'player', player);
  }

  deletePlayer(id: number) {
    return this.http.delete(this.baseUrl + 'player/' + id);
  }
}
