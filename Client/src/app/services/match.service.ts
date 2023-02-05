import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Match } from '../models/Match/match';

@Injectable({
  providedIn: 'root',
})
export class MatchService {
  private baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) {}

  getMatch(id: number) {
    return this.http.get<any>(this.baseUrl + 'match/' + id);
  }

  getMatches() {
    return this.http.get<any>(this.baseUrl + 'match');
  }

  createMatch(match: Match) {
    return this.http.post<any>(this.baseUrl + 'match', match);
  }

  updateMatch(match: Match) {
    return this.http.put<any>(this.baseUrl + 'match', match);
  }

  deleteMatch(id: number) {
    return this.http.delete<any>(this.baseUrl + 'match/' + id);
  }
}
