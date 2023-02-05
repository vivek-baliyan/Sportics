import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Team } from 'src/app/models/team';
import { TeamService } from 'src/app/services/team.service';

@Component({
  selector: 'app-team-list',
  templateUrl: './team-list.component.html',
  styleUrls: ['./team-list.component.css'],
})
export class TeamListComponent implements OnInit {
  teams: Team[];

  constructor(
    private teamService: TeamService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.getTeams();
  }

  getTeams() {
    this.teamService.getTeams().subscribe((response) => {
      this.teams = response.data;
    });
  }

  deleteTeam(id: number) {
    this.teamService.deleteTeam(id).subscribe({
      next: (response) => {
        this.toastr.success(response.msg);
        this.teams = this.teams.filter((t) => t.id !== id);
      },
      error: (err) => {
        this.toastr.error(err.error.msg);
        console.log(err.error.msg);
      },
    });
  }
}
