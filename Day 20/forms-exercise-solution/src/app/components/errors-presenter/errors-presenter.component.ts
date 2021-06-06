import { Component, Input, OnInit } from '@angular/core';

@Component({
    selector: 'app-errors-presenter',
    templateUrl: './errors-presenter.component.html',
    styleUrls: ['./errors-presenter.component.css']
})
export class ErrorsPresenterComponent implements OnInit {

    @Input() errors: any;

    constructor() { }

    ngOnInit(): void {
    }

}
