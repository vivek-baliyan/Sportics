import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Match } from 'src/app/models/Match/match';
import { Team } from 'src/app/models/team';
import { MatchService } from 'src/app/services/match.service';
import { TeamService } from 'src/app/services/team.service';

@Component({
  selector: 'app-match-create',
  templateUrl: './match-create.component.html',
  styleUrls: ['./match-create.component.css'],
})
export class MatchCreateComponent implements OnInit {
  matchForm: FormGroup;
  teams: Team[];
  match: Match;

  constructor(
    private matchService: MatchService,
    private teamService: TeamService,
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit() {
    this.matchForm = new FormGroup({
      id: new FormControl(0),
      matchNo: new FormControl(null, [Validators.required]),
      homeTeamId: new FormControl(0),
      awayTeamId: new FormControl(0),
    });

    this.getTeams();

    this.route.data.subscribe((response) => {
      if (Object.keys(response).length > 0) this.match = response.match.data;
      if (this.match != undefined && this.match != null) this.setMatch();
    });
  }

  setMatch() {
    this.matchForm.setValue({
      id: this.match.id,
      matchNo: this.match.matchNo,
      homeTeamId: isNaN(this.match.teams[0]?.teamId) ? 0 : this.match.teams[0]?.teamId,
      awayTeamId: isNaN(this.match.teams[1]?.teamId) ? 0 : this.match.teams[1]?.teamId,
    });
  }

  getTeams() {
    this.teamService.getTeams().subscribe((response) => {
      this.teams = response.data;
    });
  }

  onSubmit() {
    if (this.matchForm.valid) {
      if (this.match == undefined) this.createMatch();
      else this.updateMatch();
    }
  }

  createMatch() {
    var newMatch: Match = {
      id: 0,
      matchNo: 0,
      manOfMatch: 0,
      teams: [
        {
          id: 0,
          tossWon: false,
          matchWon: false,
          teamId: this.matchForm.value.homeTeamId,
          teamName: '',
        },
        {
          id: 0,
          tossWon: false,
          matchWon: false,
          teamId: this.matchForm.value.awayTeamId,
          teamName: '',
        },
      ],
      innings: [],
    };
    this.matchService.createMatch(newMatch).subscribe({
      next: (response) => {
        this.toastr.success(response.msg);
        this.matchForm.reset();
        this.matchForm.setValue({
          id: 0,
          firstName: '',
          lastName: '',
          teamId: 0,
        });
      },
      error: (err) => {
        this.toastr.error(err.error.msg);
        console.log(err.error.msg);
      },
    });
  }

  updateMatch() {
    var updateMatch: Match = {
      id: this.matchForm.value.id,
      matchNo: this.matchForm.value.matchNo,
      manOfMatch: 0,
      teams: [
        {
          id: 0,
          tossWon: false,
          matchWon: false,
          teamId: this.matchForm.value.homeTeamId,
          teamName: '',
        },
        {
          id: 0,
          tossWon: false,
          matchWon: false,
          teamId: this.matchForm.value.awayTeamId,
          teamName: '',
        },
      ],
      innings: [],
    };

    this.matchService.updateMatch(updateMatch).subscribe({
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
