import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Team } from '../models/team';

@Injectable({
  providedIn: 'root'
})
export class TeamService {
  private baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) {}

  getTeam(id: number) {
    return this.http.get<Team>(this.baseUrl + 'team/' + id);
  }

  getTeams() {
    return this.http.get<Team[]>(this.baseUrl + 'team');
  }

  createTeam(team: Team) {
    return this.http.post(this.baseUrl + 'team', team);
  }

  updateTeam(team: Team) {
    return this.http.put(this.baseUrl + 'team', team);
  }

  deleteTeam(id: number) {
    return this.http.delete(this.baseUrl + 'team/' + id);
  }
}
