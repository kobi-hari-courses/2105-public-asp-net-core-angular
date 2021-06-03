import { EventEmitter, OnInit, Output } from '@angular/core';
import { Directive, ElementRef, HostBinding, HostListener, Input, Renderer2 } from '@angular/core';
import { interval } from 'rxjs';
import { take } from 'rxjs/operators';

@Directive({
    selector: '[appHighlight], .blabla'
})
export class HighlightDirective implements OnInit {
    @Input()
    appHighlight: string = 'lime';

    @Output()
    removed = new EventEmitter<void>();

    @HostBinding('style.background-color')
    bgColor = this.appHighlight;



    @HostListener('click',['$event'])
    whenClicked(arg: MouseEvent) {
        console.log('when clicked');
        if (arg.ctrlKey) {
            interval(1000)
                .pipe(take(10))
                .subscribe(val => {
                if (val % 2 === 0) {
                    this.bgColor = '';
                }
                else
                {
                    this.bgColor = this.appHighlight;
                }
            });
        } else {
            console.log('Removing highlight');
            this.bgColor = '';    
            this.removed.emit();
        }
    }

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
    ngOnInit(): void {
        this.bgColor = this.appHighlight;
    }

}
