import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Team } from 'src/app/models/team';
import { TeamService } from 'src/app/services/team.service';

@Component({
  selector: 'app-team-create',
  templateUrl: './team-create.component.html',
  styleUrls: ['./team-create.component.css'],
})
export class TeamCreateComponent implements OnInit {
  teamForm: FormGroup;
  team: Team;

  constructor(
    private teamService: TeamService,
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.teamForm = new FormGroup({
      id: new FormControl(0),
      teamName: new FormControl(null, [Validators.required]),
    });

    this.route.data.subscribe((response) => {
      if (Object.keys(response).length > 0) this.team = response.team.data;
      if (this.team != undefined && this.team != null) this.setTeam();
    });
  }

  setTeam() {
    this.teamForm.setValue({ id: this.team.id, teamName: this.team.teamName });
  }

  onSubmit() {
    if (this.teamForm.valid) {
      if (this.team == undefined) this.createTeam();
      else this.updateTeam();
    }
  }

  createTeam() {
    this.teamService.createTeam(this.teamForm.value).subscribe({
      next: (response) => {
        this.toastr.success(response.msg);
        this.teamForm.reset();
      },
      error: (err) => {
        this.toastr.error(err.error.msg);
        console.log(err.error.msg);
      },
    });
  }

  updateTeam() {
    this.teamService.updateTeam(this.teamForm.value).subscribe({
      next: (response) => {
        this.toastr.success(response.msg);
        this.router.navigate(['/team/create']);
      },
      error: (err) => {
        this.toastr.error(err.error.msg);
        console.log(err.error.msg);
      },
    });
  }
}
