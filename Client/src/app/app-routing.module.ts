import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { MatchCreateComponent } from './components/matches/match-create/match-create.component';
import { MatchListComponent } from './components/matches/match-list/match-list.component';
import { PlayerCreateComponent } from './components/players/player-create/player-create.component';
import { PlayerListComponent } from './components/players/player-list/player-list.component';
import { TeamCreateComponent } from './components/teams/team-create/team-create.component';
import { TeamListComponent } from './components/teams/team-list/team-list.component';
import { MatchResolver } from './resolvers/match.resolver';
import { PlayerResolver } from './resolvers/player.resolver';
import { TeamResolver } from './resolvers/team.resolver';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'player/create', component: PlayerCreateComponent },
  {
    path: 'player/create/:id',
    component: PlayerCreateComponent,
    resolve: { player: PlayerResolver },
  },
  { path: 'player/list', component: PlayerListComponent },
  { path: 'team/create', component: TeamCreateComponent },
  {
    path: 'team/create/:id',
    component: TeamCreateComponent,
    resolve: { team: TeamResolver },
  },
  { path: 'team/list', component: TeamListComponent },
  { path: 'match/create', component: MatchCreateComponent },
  {
    path: 'match/create/:id',
    component: MatchCreateComponent,
    resolve: { match: MatchResolver },
  },
  { path: 'match/list', component: MatchListComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
