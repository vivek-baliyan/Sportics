import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TeamService } from 'src/app/services/team.service';

@Component({
  selector: 'app-team-create',
  templateUrl: './team-create.component.html',
  styleUrls: ['./team-create.component.css'],
})
export class TeamCreateComponent implements OnInit {
  teamForm: FormGroup;

  constructor(private teamService: TeamService) {}

  ngOnInit(): void {
    this.teamForm = new FormGroup({
      id: new FormControl(0),
      teamName: new FormControl(null, [Validators.required]),
    });
  }

  onSubmit() {
    console.log(this.teamForm);
    if (this.teamForm.valid) this.createTeam();
  }

  createTeam() {
    this.teamService.createTeam(this.teamForm.value).subscribe((response) => {
      console.log(response);
    });
  }
}
