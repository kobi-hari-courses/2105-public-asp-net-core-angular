import { Component, OnInit } from '@angular/core';
import { AdditionService } from 'src/app/services/addition.service';
import { WrongAdditionService } from 'src/app/services/wrong-addition.service';

@Component({
    selector: 'app-calc',
    templateUrl: './calc.component.html',
    styleUrls: ['./calc.component.css'], 
    // providers: [AdditionService]
})
export class CalcComponent implements OnInit {
    a: number = 0;
    b: number = 0;
    res: number = 0; 

    constructor(
        public additionService: AdditionService, 
        public wrongAdditionService: WrongAdditionService
    ) { }

    ngOnInit(): void {
    }

    calc() {
        this.res = this.additionService.add(this.a, this.b);
    }

    setA(value: string) {
        this.a = Number(value);
    }

    setB(value: string) {
        this.b = Number(value);
    }

}
