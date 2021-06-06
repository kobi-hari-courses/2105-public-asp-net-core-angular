import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { ErrorsPresenterComponent } from './components/errors-presenter/errors-presenter.component';

@NgModule({
  declarations: [
    AppComponent,
    ErrorsPresenterComponent
  ],
  imports: [
    BrowserModule, 
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
