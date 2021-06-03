import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'reverse'
})
export class ReversePipe implements PipeTransform {

    transform(value: unknown): string {
        if (typeof (value) !== 'string') return '';

        let res = value.split('').reverse().join('');
        return res;
    }

}
