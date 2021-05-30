import { Component } from '@angular/core';
import { BehaviorSubject, Observer, Subject } from 'rxjs';
import { interval, Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
    isShowingReader = true;

    toggleReader() {
        this.isShowingReader = !this.isShowingReader;
    }



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

    createCustomSubject(): Observable<number> {
        let res = new Subject<number>();

        res.next(100);
        setTimeout(() => res.next(200) , 2000);
        setTimeout(() => res.next(300) , 5000);
        setTimeout(() => res.next(400) , 8000);
        setTimeout(() => res.complete() , 10000);

        return res;
    }

    createCustomBehaviorSubject(): Observable<number> {
        let res = new BehaviorSubject<number>(100);

        setTimeout(() => res.next(200) , 2000);
        setTimeout(() => res.next(300) , 5000);
        setTimeout(() => res.next(400) , 8000);
        setTimeout(() => res.complete() , 10000);

        return res;

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

        let observable = this.createCustomBehaviorSubject();
        console.log('Observable Created');

        observable.subscribe(observer1);

        setTimeout(() => {
            observable.subscribe(observer2);
        }, 2500);
    }
}
