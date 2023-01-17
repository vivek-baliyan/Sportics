import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PlayerCreateComponent } from './components/players/player-create/player-create.component';
import { PlayerListComponent } from './components/players/player-list/player-list.component';

const routes: Routes = [
  { path: 'player/create', component: PlayerCreateComponent },
  { path: 'player/list', component: PlayerListComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
