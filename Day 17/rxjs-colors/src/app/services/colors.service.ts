import { Injectable } from '@angular/core';
import { ALLCOLORS } from '../models/all-colors';
import { Color } from '../models/color.model';

@Injectable({
    providedIn: 'root'
})
export class ColorsService {
    private allColors: Color[] = [];

    constructor() {
        this.allColors = Object
            .keys(ALLCOLORS)
            .map(key => ({
                code: key,
                name: ALLCOLORS[key]
            }));

        console.log(this.allColors);
    }

    private delay(millis: number): Promise<void> {
        return new Promise(resolve => setTimeout(resolve, millis));
    }

    async search(keyword: string): Promise<Color[]> {
        if (!keyword) return [];

        console.log(`Starting search for ${keyword}`);

        keyword = keyword.toLowerCase();
        let res = this.allColors
            .filter(clr => clr.name.toLowerCase().includes(keyword));

        await this.delay(2000);

        console.log(`Completed search for ${keyword}`);

        return res;
    }
}
