import { Injectable } from '@angular/core';
import {
  Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot,
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { TeamService } from '../services/team.service';

@Injectable({
  providedIn: 'root',
})
export class TeamResolver implements Resolve<any> {
  constructor(private teamService: TeamService) {}

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<any> {
    return this.teamService.getTeam(Number(route.paramMap.get('id')));
  }
}
