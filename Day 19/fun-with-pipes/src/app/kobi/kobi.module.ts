import { NgModule } from "@angular/core";
import { BlueSquareComponent } from './components/blue-square/blue-square.component';
import { GreenSqaureComponent } from './components/green-sqaure/green-sqaure.component';
import { CombinedSqaureComponent } from './components/combined-sqaure/combined-sqaure.component';
import { ReversePipe } from './pipes/reverse.pipe';
import { FilterPipe } from './pipes/filter.pipe';

@NgModule({
    declarations: [
        BlueSquareComponent,
        GreenSqaureComponent,
        CombinedSqaureComponent,
        ReversePipe,
        FilterPipe
    ],
    exports: [
        BlueSquareComponent, 
        CombinedSqaureComponent, 
        ReversePipe, 
        FilterPipe
    ]
})
export class KobiModule { }