import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

    constructor(private router: Router){}

    goRandom() {
        let possibilites = ['a', 'b', 'c'];
        let random = Date.now() % 3;
        let route = possibilites[random];
        this.router.navigateByUrl(route);
    }
}
