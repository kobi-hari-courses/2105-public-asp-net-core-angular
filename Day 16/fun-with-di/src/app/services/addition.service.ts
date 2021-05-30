import { Injectable } from "@angular/core";
import { HistoryService } from "./history.service";

@Injectable()
export class AdditionService {
    uid: number;

    constructor(
        private historyService: HistoryService
    ) {
        console.log('Creating addition service');
        this.uid = Math.ceil(Math.random() * 1000000);
    }


    add(a: number, b: number): number {
        const txt = `adding ${a} and ${b}`;
        this.historyService.logRecord(txt);
        return a + b;
    }
}