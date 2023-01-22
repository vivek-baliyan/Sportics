import { Component, OnInit } from '@angular/core';
import { Player } from 'src/app/models/player';
import { PlayerService } from 'src/app/services/player.service';

@Component({
  selector: 'app-player-list',
  templateUrl: './player-list.component.html',
  styleUrls: ['./player-list.component.css'],
})
export class PlayerListComponent implements OnInit {
  players: Player[];

  constructor(private PlayerService: PlayerService) {}

  ngOnInit(): void {
    this.getPlayers();
  }

  getPlayers() {
    this.PlayerService.getPlayers().subscribe((response) => {
      this.players = response.data;
    });
  }

  deletePlayer(id: number) {
    this.PlayerService.deletePlayer(id).subscribe((response) => {
      console.log(response.msg);
      this.players = this.players.filter((t) => t.id !== id);
    });
  }
}
