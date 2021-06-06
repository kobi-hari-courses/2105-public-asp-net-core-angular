import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { addQuestion, reset } from './redux/app.actions';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
    constructor(
        private store: Store<any>
        ){}

    reset() {
        let action = reset();
        this.store.dispatch(action);
    }
}
