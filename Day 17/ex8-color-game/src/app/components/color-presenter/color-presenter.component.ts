import { Component, Input, OnInit } from '@angular/core';

@Component({
    selector: 'app-color-presenter',
    templateUrl: './color-presenter.component.html',
    styleUrls: ['./color-presenter.component.css']
})
export class ColorPresenterComponent {
    @Input()
    color: string | null = '';
}
