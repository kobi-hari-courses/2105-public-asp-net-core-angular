import { Component } from '@angular/core';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    title = 'fun with pipes';
    today = Date.now();

    colors: string[] = [
        'red', 
        'green', 
        'blue', 
        'orange', 
        'yellow', 
        'cyan', 
        'beer'
    ];

    addColor(value: string) {
        this.colors.push(value);
        console.log(this.colors);

//        this.colors = [...this.colors, value];
    }

}
