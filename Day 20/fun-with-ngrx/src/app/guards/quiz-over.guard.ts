import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { first } from 'rxjs/operators';
import { selectIsQuizDone } from '../redux/app.selectors';

@Injectable({
    providedIn: 'root'
})
export class QuizOverGuard implements CanActivate {
    constructor(private router: Router, private store: Store<any>){}

    async canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Promise<true | UrlTree> {

        console.log('running quiz over guard');
        let isOver = await this.store.select(selectIsQuizDone)
                        .pipe(first())
                        .toPromise();
        console.log('is over = ', isOver);

        if (!isOver) return true;
        return this.router.createUrlTree(['results']);
    }

}
