import { Injectable } from '@angular/core';
import {
  Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot,
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { PlayerService } from '../services/player.service';

@Injectable({
  providedIn: 'root',
})
export class PlayerResolver implements Resolve<any> {
  constructor(private playerService: PlayerService) {}

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<any> {
    return this.playerService.getPlayer(Number(route.paramMap.get('id')));
  }
}
