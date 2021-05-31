import { Component, OnInit } from '@angular/core';
import { BehaviorSubject, merge, Observable } from 'rxjs';
import { Color } from './models/color.model';
import { ColorsService } from './services/colors.service';
import { debounceTime, distinctUntilChanged, map, mapTo, mergeMap, switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
    search$ = new BehaviorSubject<string>('');
    results$!: Observable<Color[]>;
    isBusy$!: Observable<boolean>;

    constructor(private colorsService: ColorsService) {
    }

    ngOnInit(): void {
        this.results$ = this.search$.pipe(
            debounceTime(500),
            switchMap(kw => this.colorsService.search(kw))
        );

        let true$ = this.search$.pipe(mapTo(true));
        let false$ = this.results$.pipe(mapTo(false));

        let merged$ = merge(true$, false$);

        this.isBusy$ = merged$.pipe(
            distinctUntilChanged()
        );
    }

    setKeyword(value: string) {
        this.search$.next(value);
    }
}
