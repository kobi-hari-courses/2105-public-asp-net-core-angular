import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class AuthenticationService {
    private isLoggedIn$ = new BehaviorSubject<boolean>(false);

    constructor() { }

    login() {
        this.isLoggedIn$.next(true);
    }

    logout() {
        this.isLoggedIn$.next(false);
    }

    isLoggedIn(): Observable<boolean> {
        return this.isLoggedIn$.asObservable();
    }
}
