import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'fun-with-directives';

  myFavoriteColor = 'green';

  whenClicked(arg: MouseEvent) {
      console.log('app component when clicked');

      if (arg.ctrlKey) {
          console.log('And you are holding the control key');
      }
  }

  onRemoved(name: string) {
      console.log(name + ' removed');
  }


}
