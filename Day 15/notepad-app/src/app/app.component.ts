import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
    // data
    colors: string[] = ['red', 'green', 'blue', 'brown', 'magenta', 'navy', 'salmon', 'black'];
    sizes: string[] = ['14px', '18px', '24px', '40px', '80px'];
    fonts: string[] = ['Arial', 'Verdana', 'Roboto', 'David', 'Segoe UI', 'Courier New'];

    selectedColor: string = this.colors[0];
    selectedSize: string = this.sizes[0];
    selectedFont: string = this.fonts[0];

    title: string = 'Amazing Notepad';


    // methods
    selectColor(value: string) {
        console.log('selecting color ' + value);
        this.selectedColor = value;
    }

    selectFont(value: string) {
        this.selectedFont = value;
    }

    selectSize(value: string) {
        this.selectedSize = value;
    }
}
