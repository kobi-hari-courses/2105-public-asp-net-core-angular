import { Directive, ElementRef, HostBinding, Renderer2 } from '@angular/core';
import { interval } from 'rxjs';

@Directive({
    selector: '[appHighlight]'
})
export class HighlightDirective {
    @HostBinding('style.background-color')
    bgColor = 'lime';


    constructor(
        private elem: ElementRef,
        private renderer: Renderer2) {

        // elem.nativeElement.style.backgroundColor = 'yellow';

        // this.renderer.setStyle(elem.nativeElement, 'background-color', 'pink');

        // interval(1000).subscribe(val => {
        //     if (val % 2 == 0) {
        //         this.bgColor = 'lime';
        //     } else {
        //         this.bgColor = 'green';
        //     }
        // })

    }

}
