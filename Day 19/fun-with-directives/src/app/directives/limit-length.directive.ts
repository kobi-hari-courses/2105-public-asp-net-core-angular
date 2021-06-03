import { Directive, ElementRef, HostBinding, HostListener, Input } from '@angular/core';

@Directive({
  selector: 'input[type="text"]'
})
export class LimitLengthDirective {
    private lastLegalValue = ''; 
    
    @Input()
    maxLength: number = 5;

    @HostListener('input', ['$event.target.value'])
    onInput(value: string) {
        // let value = this.elem.nativeElement.value as string;
        if (value.length <= this.maxLength) {
            this.lastLegalValue = value;
        } else {
            this.elem.nativeElement.value = this.lastLegalValue;
        }
    }

    @HostBinding('style.border')
    border = '2px solid red';


  constructor(private elem: ElementRef) { 
      console.log('max length directive created');
  }

}
