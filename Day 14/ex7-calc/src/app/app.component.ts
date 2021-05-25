import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
    a: number = 0;
    b: number = 0;

    sum: number | null = null;
    difference: number | null = null;
    product: number | null = null;

    get hasResults(): boolean {
        return (this.sum !== null) &&
        (this.difference !== null) &&
        (this.product !== null);
    }

    private _reset() {
        this.sum = null;
        this.difference = null;
        this.product = null;        
    }

    setA(value: string) {
        this.a = Number(value);
        this._reset();
    }

    setB(value: string) {
        this.b = Number(value);
        this._reset();
    }

    calc() {
        if ((this.a === null) || (this.b === null)) {
            this._reset();
        } else {
            this.sum = this.a + this.b;
            this.difference = this.a - this.b;
            this.product = this.a * this.b;
        }
    }
}
