import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { UserType } from 'src/app/models/user-type.model';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
    selector: 'app-account',
    templateUrl: './account.component.html',
    styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {
    userType$!: Observable<UserType>;
    isLoggedIn$!: Observable<boolean>;

    constructor(private auth: AuthenticationService) { }

    private userType(isLoggedIn: boolean): UserType {
        if (isLoggedIn) return 'Admin';
        return 'Guest';
    }

    ngOnInit(): void {
        this.isLoggedIn$ = this.auth.isLoggedIn();
        this.userType$ = this.isLoggedIn$.pipe(
            map(res => this.userType(res))
        );
    }

    login() {
        this.auth.login();
    }

    logout() {
        this.auth.logout();
    }

}
