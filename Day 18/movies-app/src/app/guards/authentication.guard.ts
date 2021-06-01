import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { filter, first } from 'rxjs/operators';
import { AuthenticationService } from '../services/authentication.service';

@Injectable({
    providedIn: 'root'
})
export class AuthenticationGuard implements CanActivate {
    constructor(
        private auth: AuthenticationService, 
        private router: Router) { }

    async canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Promise<true | UrlTree> {

        console.log('Guard is checking authentication');

        let isLoggedIn = await this.auth
            .isLoggedIn()
            .pipe(first())
            .toPromise();

        console.log('Guard result: ' + isLoggedIn);

        if (isLoggedIn) return true;

        let targetUrl = state.url;

        this.auth.isLoggedIn().pipe(
            filter(val => val === true), 
            first()
        ).subscribe(_ => {
            this.router.navigateByUrl(targetUrl);
        });

        return this.router.parseUrl('account');


    }

}
