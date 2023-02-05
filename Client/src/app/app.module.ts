import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PlayerCreateComponent } from './components/players/player-create/player-create.component';
import { PlayerListComponent } from './components/players/player-list/player-list.component';
import { TeamCreateComponent } from './components/teams/team-create/team-create.component';
import { TeamListComponent } from './components/teams/team-list/team-list.component';
import { HomeComponent } from './components/home/home.component';
import { NavComponent } from './components/nav/nav.component';
import { ToastrModule } from 'ngx-toastr';
import { MatchListComponent } from './components/matches/match-list/match-list.component';
import { MatchCreateComponent } from './components/matches/match-create/match-create.component';

@NgModule({
  declarations: [
    AppComponent,
    TeamCreateComponent,
    TeamListComponent,
    PlayerListComponent,
    PlayerCreateComponent,
    HomeComponent,
    NavComponent,
    MatchListComponent,
    MatchCreateComponent,
  ],
  imports: [
    BrowserModule,
    CommonModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
    }),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
