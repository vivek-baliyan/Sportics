import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Team } from '../models/team';

@Injectable({
  providedIn: 'root',
})
export class TeamService {
  private baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) {}

  getTeam(id: number) {
    return this.http.get<any>(this.baseUrl + 'team/' + id);
  }

  getTeams() {
    return this.http.get<any>(this.baseUrl + 'team');
  }

  createTeam(team: Team) {
    return this.http.post<any>(this.baseUrl + 'team', team);
  }

  updateTeam(team: Team) {
    return this.http.put<any>(this.baseUrl + 'team', team);
  }

  deleteTeam(id: number) {
    return this.http.delete<any>(this.baseUrl + 'team/' + id);
  }
}
