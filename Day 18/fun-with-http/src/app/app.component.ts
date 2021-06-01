import { Component, OnInit } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Movie } from './models/movie.model';
import { DataService } from './services/data.service';
import { switchMap, filter } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
    movie$!: Observable<Movie>;

    private id$ = new BehaviorSubject<string>('');

    constructor(private dataService: DataService){}

    ngOnInit(): void {
        this.movie$ = this.id$.pipe(
            filter(id => id !==''), 
            switchMap(id => this.dataService.getMovieById(id))
        );
    }

    search(id: string) {
        this.id$.next(id);
    }
}
