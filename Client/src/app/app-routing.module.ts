import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { PlayerCreateComponent } from './components/players/player-create/player-create.component';
import { PlayerListComponent } from './components/players/player-list/player-list.component';
import { TeamCreateComponent } from './components/teams/team-create/team-create.component';
import { TeamListComponent } from './components/teams/team-list/team-list.component';
import { TeamResolver } from './resolvers/team.resolver';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'player/create', component: PlayerCreateComponent },
  { path: 'player/create/:id', component: PlayerCreateComponent },
  { path: 'player/list', component: PlayerListComponent },
  { path: 'team/create', component: TeamCreateComponent },
  {
    path: 'team/create/:id',
    component: TeamCreateComponent,
    resolve: { team: TeamResolver },
  },
  { path: 'team/list', component: TeamListComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
