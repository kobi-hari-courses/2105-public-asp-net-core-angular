import { Component, OnInit } from '@angular/core';
import { GameService } from 'src/app/services/game.service';

@Component({
    selector: 'app-color-editor',
    templateUrl: './color-editor.component.html',
    styleUrls: ['./color-editor.component.css']
})
export class ColorEditorComponent implements OnInit {

    constructor(private game: GameService) { }

    ngOnInit(): void {
    }

    private normlize(num: string): number {
        let val = Math.round(Number(num));
        return Math.min(Math.max(0, val), 255);
    }

    setR(value: string) {
        this.game.setRed(this.normlize(value));
    }

    setG(value: string) {
        this.game.setGreen(this.normlize(value));
    }

    setB(value: string) {
        this.game.setBlue(this.normlize(value));
    }

}
