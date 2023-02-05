import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Player } from 'src/app/models/player';
import { PlayerService } from 'src/app/services/player.service';

@Component({
  selector: 'app-player-list',
  templateUrl: './player-list.component.html',
  styleUrls: ['./player-list.component.css'],
})
export class PlayerListComponent implements OnInit {
  players: Player[];

  constructor(
    private playerService: PlayerService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.getPlayers();
  }

  getPlayers() {
    this.playerService.getPlayers().subscribe((response) => {
      this.players = response.data;
    });
  }

  deletePlayer(id: number) {
    this.playerService.deletePlayer(id).subscribe({
      next: (response) => {
        this.toastr.success(response.msg);
        this.players = this.players.filter((t) => t.id !== id);
      },
      error: (err) => {
        this.toastr.error(err.error.msg);
        console.log(err.error.msg);
      },
    });
  }
}
