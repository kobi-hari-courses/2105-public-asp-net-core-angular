import { Component } from '@angular/core';
import { Person } from './person.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
    people: Person[] = [
        {
            firstName: 'john', 
            lastName: 'lennon', 
            title: 'sir'
        }, 
        {
            firstName: 'paul', 
            lastName: 'mccartney', 
            title: 'sir'
        }, 
        {
            firstName: 'ringo', 
            lastName: 'starr', 
            title: 'sir'
        }

    ]

    showNames: boolean = true;

    items = [1, 2, 3, 4];

    toggleNames() {
        this.showNames = !this.showNames;
    }
}
