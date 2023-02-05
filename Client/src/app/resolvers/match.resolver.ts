import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { MatchService } from '../services/match.service';

@Injectable({
  providedIn: 'root'
})
export class MatchResolver implements Resolve<boolean> {
  constructor(private matchService: MatchService) {}

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<any> {
    return this.matchService.getMatch(Number(route.paramMap.get('id')));
  }
}
