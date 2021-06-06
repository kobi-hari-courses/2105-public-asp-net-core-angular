import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { appReducer } from './redux/app.reducer';
import { AddQuestionComponent } from './components/add-question/add-question.component';
import { ReactiveFormsModule } from '@angular/forms';
import { QuestionListComponent } from './components/question-list/question-list.component';
import { QuestionDetailsComponent } from './components/question-details/question-details.component';
import { AnswerQuestionComponent } from './components/answer-question/answer-question.component';
import { QuizResultsComponent } from './components/quiz-results/quiz-results.component';
import { environment } from 'src/environments/environment';

@NgModule({
  declarations: [
    AppComponent,
    AddQuestionComponent,
    QuestionListComponent,
    QuestionDetailsComponent,
    AnswerQuestionComponent,
    QuizResultsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule, 
    ReactiveFormsModule,
    StoreModule.forRoot({
        app: appReducer
    }), 
    StoreDevtoolsModule.instrument({maxAge: 50, logOnly: environment.production})
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
