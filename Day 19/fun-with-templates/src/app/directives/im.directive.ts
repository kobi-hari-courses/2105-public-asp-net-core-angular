import { Directive, ElementRef, Input, OnInit, TemplateRef, ViewContainerRef } from '@angular/core';

@Directive({
    selector: '[appIm]'
})
export class ImDirective implements OnInit {
    private _appIm: boolean = false;
    private _appImTimes: number = 1;

    @Input()
    get appIm(): boolean { return this._appIm; }
    set appIm(value: boolean) {
        this._appIm = value;
        this.invalidate();
    }

    @Input()
    get appImTimes(): number { return this._appImTimes;}
    set appImTimes(value: number) {
        this._appImTimes = value;
        this.invalidate();
    }



    invalidate() {
        this.viewContainer.clear();

        if (this._appIm) {
            for (let i = 0; i < this.appImTimes; i++) {
                this.viewContainer.createEmbeddedView(this.template);
            }
        } 
    }

    constructor(
        private template: TemplateRef<any>, 
        private viewContainer: ViewContainerRef) { }

    ngOnInit(): void {
        console.log('my element is: ', this.template);
    }

}
