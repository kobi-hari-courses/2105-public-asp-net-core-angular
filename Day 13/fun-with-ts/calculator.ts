export class Calculator {
    constructor(
        private a: number, 
        private b: number
    ) {        
    }

    add(): number {
        return this.a + this.b;
    }

    subtract(): number {
        return this.a - this.b;
    }

    multiply(): number {
        return this.a * this.b;
    }

    log() {
        console.log(`${this.a} + ${this.b} = ${this.add()}`);
        console.log(`${this.a} - ${this.b} = ${this.subtract()}`);
        console.log(`${this.a} * ${this.b} = ${this.multiply()}`);
    }
}

