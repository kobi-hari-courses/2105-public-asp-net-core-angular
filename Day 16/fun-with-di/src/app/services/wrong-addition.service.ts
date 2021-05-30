import { Injectable } from "@angular/core";
import { HistoryService } from "./history.service";

@Injectable({
    providedIn: 'root'
})
export class WrongAdditionService {
    uid: number;

    constructor(
        private historyService: HistoryService
    ) {
        console.log('Creating wrong addition service');
        this.uid = Math.ceil(Math.random() * 1000000);
    }


    add(a: number, b: number): number {
        const txt = `wrongly adding ${a} and ${b}`;
        this.historyService.logRecord(txt);
        return a + b + 1;
    }
}