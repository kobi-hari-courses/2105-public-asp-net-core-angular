import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'filter', 
    pure: false
})
export class FilterPipe implements PipeTransform {

    transform(value: unknown, keyword: unknown): string[] {
        if (!value) return [];

        if (typeof (value) !== 'object') return [];

        if (!(value instanceof Array)) return [];

        if (typeof (keyword) !== 'string') return [];


        return value
            .map(item => `${item}`)
            .filter(item => item.includes(keyword));

    }
}
