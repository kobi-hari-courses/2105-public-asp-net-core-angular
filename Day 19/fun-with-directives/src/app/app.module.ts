import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HighlightDirective } from './directives/highlight.directive';
import { LimitLengthDirective } from './directives/limit-length.directive';
import { ColoredTextComponent } from './colored-text/colored-text.component';
import { RowFillerComponent } from './row-filler/row-filler.component';

@NgModule({
  declarations: [
    AppComponent,
    HighlightDirective,
    LimitLengthDirective,
    ColoredTextComponent,
    RowFillerComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
