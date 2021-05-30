import { Component } from '@angular/core';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    private delay(time: number): Promise<number> {
        return new Promise((success, basa) => {
            setTimeout(() => success(42), time)
        });

        // return new Promise((success, fail) => {
        //     setTimeout(() => {
        //         fail('Ki lo ba li');
        //     }, 2000);
        // })
    }

    private async verySlowHello(): Promise<string> {
        await this.delay(3000);
        return 'Hello';
    }


    async go() {
        console.log('Here we go!');

        let p1 = this.delay(2000);
        let p2 = this.verySlowHello();

        let pall = Promise.all([p1, p2]);
        let resAll = await pall;

        let pany = Promise.race([p1, p2]);
        let resAny = await pany;




        console.log(resAll);
    }
}
