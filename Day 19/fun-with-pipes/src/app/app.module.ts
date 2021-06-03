import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { RedSquareComponent } from './components/red-square/red-square.component';
import { GreenSqaureComponent } from './kobi/components/green-sqaure/green-sqaure.component';
import { KobiModule } from './kobi/kobi.module';

@NgModule({
  declarations: [
    AppComponent,
    RedSquareComponent
  ],
  imports: [
    BrowserModule, 
    KobiModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
