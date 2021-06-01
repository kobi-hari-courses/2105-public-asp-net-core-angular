import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Movie } from '../models/movie.model';
import { map } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class DataService {
    readonly baseUrl: string = 'http://localhost:3000';

    constructor(private http: HttpClient) { }

    getNumberOfMovies(): Promise<number> {
        const url = `${this.baseUrl}/movies`;

        return this.http
            .get<Movie[]>(url)
            .pipe(map(list => list.length))
            .toPromise();
    }

    getCaptionsOfMovies(): Promise<string[]> {
        const url = `${this.baseUrl}/movies`;

        return this.http
            .get<Movie[]>(url)
            .pipe(map(list => list.map(m => m.caption)))
            .toPromise();
    }

    getMovieByIndex(index: number): Promise<Movie> {
        const url = `${this.baseUrl}/movies`;
        return this.http
            .get<Movie[]>(url)
            .pipe(map(list => list[index-1]))
            .toPromise();
    }
}
