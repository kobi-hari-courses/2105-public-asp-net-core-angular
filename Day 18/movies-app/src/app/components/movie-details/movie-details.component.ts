import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { combineLatest, from, Observable, of } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';
import { Movie } from 'src/app/models/movie.model';
import { DataService } from 'src/app/services/data.service';

@Component({
    selector: 'app-movie-details',
    templateUrl: './movie-details.component.html',
    styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {
    movie$!: Observable<Movie>;

    hasNext$!: Observable<boolean>;
    hasPrev$!: Observable<boolean>;

    constructor(
        private data: DataService, 
        private route: ActivatedRoute, 
        private router: Router
        ) { }

    ngOnInit(): void {
//        let index = Number(this.route.snapshot.params['index']);
        let index$ = this.route.params.pipe(
            map(prms => Number(prms['index']))
        );

        this.movie$ = index$.pipe(
            switchMap(index => this.data.getMovieByIndex(index))
        );

        this.hasPrev$ = index$.pipe(
            map(index => index > 1)
        );

        let totalCount$ = from(this.data.getNumberOfMovies());
        this.hasNext$ = combineLatest([index$, totalCount$]).pipe(
            map(tpl => tpl[0] < tpl[1])
        );

    }

    gotoNext() {
        let index = Number(this.route.snapshot.params['index']);
        this.router.navigate(['movies', index + 1]);
    }

    gotoPrev() {
        let index = Number(this.route.snapshot.params['index']);
        this.router.navigate(['movies', index - 1]);
    }

    gotoEdit() {
        let index = Number(this.route.snapshot.params['index']);
        this.router.navigate(['movies', index, 'edit']);
    }

}
