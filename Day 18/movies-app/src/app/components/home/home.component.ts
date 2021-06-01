import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/services/data.service';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
    numberOfMovies$!: Promise<number>;

    constructor(private data: DataService) { }

    ngOnInit(): void {
        this.numberOfMovies$ = this.data.getNumberOfMovies();
    }

}
