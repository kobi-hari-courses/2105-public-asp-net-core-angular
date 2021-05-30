import { Component } from '@angular/core';
import { observable, Observer } from 'rxjs';
import { interval, Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
    createIntervalObservable(): Observable<number> {
        return interval(1000);
    }

    createCustomObservable(): Observable<number> {
        return new Observable<number>(observer => {
            observer.next(100);
            setTimeout(() => observer.next(200) , 2000);
            setTimeout(() => observer.next(300) , 5000);
            setTimeout(() => observer.next(400) , 8000);
            setTimeout(() => observer.complete() , 10000);
        })
    }

    createObserver(id: string): Observer<number> {
        return {
            next: val => console.log(`observer ${id}: next ${val}`), 
            complete: () => console.log(`observer ${id}: completed`), 
            error: err => console.log(`observer ${id}: error ${err}`)
        };
    }

    go() {
        let observer1 = this.createObserver('A');
        let observer2 = this.createObserver('B');

        let observable = this.createCustomObservable();

        observable.subscribe(observer1);

        setTimeout(() => {
            observable.subscribe(observer2);
        }, 2500);
    }
}
