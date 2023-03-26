import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Tournament } from '../models/tournament/tournament';

@Injectable({
  providedIn: 'root',
})
export class TournamentService {
  private baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) {}

  getTournament(id: number) {
    return this.http.get<any>(this.baseUrl + 'tournament/' + id);
  }

  getTournamentes() {
    return this.http.get<any>(this.baseUrl + 'tournament');
  }
}
