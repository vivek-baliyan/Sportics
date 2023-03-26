import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
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
    private formBuilder: FormBuilder,
    private teamService: TeamService,
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.teamForm = this.formBuilder.group({
      id: [0],
      teamName: [null, [Validators.required]],
      homeCity: [null, [Validators.required]],
      coach: [null, [Validators.required]],
    });

    this.route.data.subscribe((response) => {
      if (Object.keys(response).length > 0) this.team = response.team.data;
      if (this.team != undefined && this.team != null) this.setTeam();
    });
  }

  setTeam() {
    this.teamForm.setValue({
      id: this.team.id,
      teamName: this.team.teamName,
      homeCity: this.team.homeCity,
      coach: this.team.coach,
    });
  }

  onSubmit() {
    if (this.teamForm.valid) {
      const formValue = this.teamForm.value;
      if (!formValue.id) {
        formValue.id = 0; // Assign a default value to the id field
      }
      if (this.team == undefined) this.createTeam(formValue);
      else this.updateTeam(formValue);
    }
  }

  createTeam(formValue: any) {
    this.teamService.createTeam(formValue).subscribe({
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

  updateTeam(formValue: any) {
    this.teamService.updateTeam(formValue).subscribe({
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
