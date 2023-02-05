import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Match } from 'src/app/models/Match/match';
import { MatchService } from 'src/app/services/match.service';

@Component({
  selector: 'app-match-list',
  templateUrl: './match-list.component.html',
  styleUrls: ['./match-list.component.css'],
})
export class MatchListComponent implements OnInit {
  matches: Match[];

  constructor(
    private matchService: MatchService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.getMatches();
  }

  getMatches() {
    this.matchService.getMatches().subscribe((response) => {
      this.matches = response.data;
    });
  }

  deleteMatch(id: number) {
    this.matchService.deleteMatch(id).subscribe({
      next: (response) => {
        this.toastr.success(response.msg);
        this.matches = this.matches.filter((t) => t.id !== id);
      },
      error: (err) => {
        this.toastr.error(err.error.msg);
        console.log(err.error.msg);
      },
    });
  }
}
