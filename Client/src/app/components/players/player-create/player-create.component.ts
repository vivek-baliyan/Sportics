import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Player } from 'src/app/models/player';
import { Team } from 'src/app/models/team';
import { PlayerService } from 'src/app/services/player.service';
import { TeamService } from 'src/app/services/team.service';

@Component({
  selector: 'app-player-create',
  templateUrl: './player-create.component.html',
  styleUrls: ['./player-create.component.css'],
})
export class PlayerCreateComponent implements OnInit {
  playerForm: FormGroup;
  teams: Team[];
  player: Player;

  constructor(
    private playerService: PlayerService,
    private teamService: TeamService,
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit() {
    this.playerForm = new FormGroup({
      id: new FormControl(0),
      firstName: new FormControl(null, [Validators.required]),
      lastName: new FormControl(null),
      teamId: new FormControl(0),
    });

    this.getTeams();

    this.route.data.subscribe((response) => {
      if (Object.keys(response).length > 0) this.player = response.player.data;
      if (this.player != undefined && this.player != null) this.setPlayer();
    });
  }

  setPlayer() {
    this.playerForm.setValue({
      id: this.player.id,
      firstName: this.player.firstName,
      lastName: this.player.lastName,
      teamId: this.player.teamId,
    });
  }

  getTeams() {
    this.teamService.getTeams().subscribe((response) => {
      this.teams = response.data;
    });
  }

  onSubmit() {
    if (this.playerForm.valid) {
      if (this.player == undefined) this.createPlayer();
      else this.updatePlayer();
    }
  }

  createPlayer() {
    this.playerService.createPlayer(this.playerForm.value).subscribe({
      next: (response) => {
        this.toastr.success(response.msg);
        this.playerForm.reset();
        this.playerForm.setValue({
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

  updatePlayer() {
    this.playerService.updatePlayer(this.playerForm.value).subscribe({
      next: (response) => {
        this.toastr.success(response.msg);
        this.router.navigate(['/player/create']);
      },
      error: (err) => {
        this.toastr.error(err.error.msg);
        console.log(err.error.msg);
      },
    });
  }
}
