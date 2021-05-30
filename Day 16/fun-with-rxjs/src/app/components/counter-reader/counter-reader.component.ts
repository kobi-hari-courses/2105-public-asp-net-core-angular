import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { CounterService } from 'src/app/services/counter.service';

@Component({
    selector: 'app-counter-reader',
    templateUrl: './counter-reader.component.html',
    styleUrls: ['./counter-reader.component.css']
})
export class CounterReaderComponent implements OnInit, OnDestroy {
    value: number = 0;
    sub: Subscription | null = null;

    constructor(private counterService: CounterService) { }

    ngOnInit(): void {
        this.sub = this.counterService.getValue().subscribe(val => {
            this.value = val;
            console.log('received a new value: ' + val);
        })
    }

    ngOnDestroy(): void {
        this.sub?.unsubscribe();
    }

}
