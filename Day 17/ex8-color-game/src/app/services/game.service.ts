import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Rgb } from '../models/types';

@Injectable({
    providedIn: 'root'
})
export class GameService {
    private r: number = 0;
    private g: number = 0;
    private b: number = 0;
    private curColor: Rgb = [0, 0, 0];

    private r$ = new BehaviorSubject(0);
    private g$ = new BehaviorSubject(0);
    private b$ = new BehaviorSubject(0);
    private curColor$ = new BehaviorSubject<Rgb>([0, 0, 0]);

    constructor() { }

    getRed(): Observable<number> {
        return this.r$.asObservable();
    }

    getGreen(): Observable<number> {
        return this.g$.asObservable();
    }
    getBlue(): Observable<number> {
        return this.b$.asObservable();
    }
    
    getComputerColor(): Observable<Rgb> {
        return this.curColor$.asObservable();
    }

    setRed(value: number) {
        this.r = value;
        this.r$.next(this.r);
    }
 
    setGreen(value: number) {
        this.g = value;
        this.g$.next(this.g);
    }
    
    setBlue(value: number) {
        this.b = value;
        this.b$.next(this.b);
    }

    private rndByte(): number {
        return Math.floor(Math.random() * 256);
    }

    randomizeColor() {
        let rndColor: Rgb = [this.rndByte(), this.rndByte(), this.rndByte()];
        this.curColor = rndColor;
        this.curColor$.next(this.curColor);
    }


}
