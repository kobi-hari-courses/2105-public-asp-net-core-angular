import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Movie } from '../models/movie.model';

@Injectable({
    providedIn: 'root'
})
export class DataService {
    constructor(private http: HttpClient) { }

    getMovieById(id: string): Promise<Movie> {
        console.log('searching for id : ' + id);

        return this.http
            .get<Movie>('http://localhost:3000/movies/' + id)
            .toPromise();
    }
}
