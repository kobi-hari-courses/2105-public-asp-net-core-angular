import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountComponent } from './components/account/account.component';
import { HomeComponent } from './components/home/home.component';
import { MovieDetailsComponent } from './components/movie-details/movie-details.component';
import { MovieEditComponent } from './components/movie-edit/movie-edit.component';
import { MoviesComponent } from './components/movies/movies.component';
import { AuthenticationGuard } from './guards/authentication.guard';

const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent }, 
    { path: 'movies', component: MoviesComponent }, 
    { path: 'movies/:index', component: MovieDetailsComponent },
    { path: 'movies/:index/edit', component: MovieEditComponent, canActivate: [AuthenticationGuard] },
    { path: 'account', component: AccountComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
