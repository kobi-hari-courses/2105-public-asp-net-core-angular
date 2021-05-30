import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class CounterService {
    private value: number = 0;
    // private value$ = new BehaviorSubject<number>(this.value);
    private value$ = new Subject<number>();


    constructor() { }

    increment() {
        this.value++;
        this.value$.next(this.value);
    }

    decrement() {
        this.value--;
        this.value$.next(this.value);
    }

    getValue(): Observable<number> {
        return this.value$.asObservable();
    }
}
