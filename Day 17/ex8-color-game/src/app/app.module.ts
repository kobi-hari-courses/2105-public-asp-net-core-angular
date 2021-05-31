import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ColorEditorComponent } from './components/color-editor/color-editor.component';
import { ColorPresenterComponent } from './components/color-presenter/color-presenter.component';

@NgModule({
  declarations: [
    AppComponent,
    ColorEditorComponent,
    ColorPresenterComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
