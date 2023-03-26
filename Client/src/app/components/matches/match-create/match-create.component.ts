import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Match } from 'src/app/models/match/match';
import { Team } from 'src/app/models/team';
import { Tournament } from 'src/app/models/tournament/tournament';
import { MatchService } from 'src/app/services/match.service';
import { TeamService } from 'src/app/services/team.service';
import { TournamentService } from 'src/app/services/tournament.service';

@Component({
  selector: 'app-match-create',
  templateUrl: './match-create.component.html',
  styleUrls: ['./match-create.component.css'],
})
export class MatchCreateComponent implements OnInit {
  matchForm: FormGroup;
  teams: Team[];
  tournaments: Tournament[];
  match: Match;

  constructor(
    private matchService: MatchService,
    private teamService: TeamService,
    private tournamentService:TournamentService,
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit() {
    this.matchForm = new FormGroup({
      id: new FormControl(0),
      matchNo: new FormControl(null, [Validators.required]),
      matchDate: new FormControl(new Date(), [Validators.required]),
      venue: new FormControl(null, [Validators.required]),
      team1Id: new FormControl(0),
      team2Id: new FormControl(0),
      tournamentId: new FormControl(0),
    });

    this.getTeams();
    this.getTournaments();

    this.route.data.subscribe((response) => {
      if (Object.keys(response).length > 0) this.match = response.match.data;
      if (this.match != undefined && this.match != null) this.setMatch();
    });
  }

  setMatch() {
    this.matchForm.setValue({
      id: this.match.id,
      matchNo: this.match.matchNo,
      matchDate: this.match.matchDate,
      venue: this.match.venue,
      team1Id: this.match.team1Id,
      team2Id: this.match.team2Id,
      tournamentId:this.match.tournamentId
    });
  }

  getTeams() {
    this.teamService.getTeams().subscribe((response) => {
      this.teams = response.data;
    });
  }
  
  getTournaments() {
    this.tournamentService.getTournamentes().subscribe((response) => {
      this.tournaments = response.data;
    });
  }

  onSubmit() {
    if (this.matchForm.valid) {
      if (this.match == undefined) this.createMatch();
      else this.updateMatch();
    }
  }

  createMatch() {
    this.matchService.createMatch(this.matchForm.value).subscribe({
      next: (response) => {
        this.toastr.success(response.msg);
        this.matchForm.reset();
      },
      error: (err) => {
        this.toastr.error(err.error.msg);
        console.log(err.error.msg);
      },
    });
  }

  updateMatch() {
    this.matchService.updateMatch(this.matchForm.value).subscribe({
      next: (response) => {
        this.toastr.success(response.msg);
        this.router.navigate(['/match/create']);
      },
      error: (err) => {
        this.toastr.error(err.error.msg);
        console.log(err.error.msg);
      },
    });
  }
}
