import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { PlayerService } from 'src/app/services/player.service';

@Component({
  selector: 'app-player-create',
  templateUrl: './player-create.component.html',
  styleUrls: ['./player-create.component.css'],
})
export class PlayerCreateComponent implements OnInit {
  playerForm: FormGroup;

  constructor() {}

  ngOnInit() {
    this.playerForm = new FormGroup({
      playerData: new FormGroup({
        playerName: new FormControl(null, [Validators.required]),
      }),
    });
  }

  onSubmit() {
    console.log(this.playerForm.value);
    this.playerForm.reset();
  }
}
