import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
    isLoggedIn$!: Observable<boolean>;

  constructor(private auth: AuthenticationService) { }

  ngOnInit(): void {
      this.isLoggedIn$ = this.auth.isLoggedIn();
  }

}
