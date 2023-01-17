import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Player } from '../models/Player';

@Injectable({
  providedIn: 'root',
})
export class PlayerService {
  private baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) {}

  getPlayers() {
    return this.http.get<Player[]>(this.baseUrl + 'player');
  }
}
