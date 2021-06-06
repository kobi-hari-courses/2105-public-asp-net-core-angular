import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddQuestionComponent } from './components/add-question/add-question.component';
import { AnswerQuestionComponent } from './components/answer-question/answer-question.component';
import { QuestionDetailsComponent } from './components/question-details/question-details.component';
import { QuestionListComponent } from './components/question-list/question-list.component';
import { QuizResultsComponent } from './components/quiz-results/quiz-results.component';
import { QuizOverGuard } from './guards/quiz-over.guard';

const routes: Routes = [
    {path: 'questions', component: QuestionListComponent}, 
    {path: 'questions/add', component: AddQuestionComponent }, 
    {path: 'questions/view/:index', component: QuestionDetailsComponent}, 
    {path: 'run', component: AnswerQuestionComponent, canActivate: [QuizOverGuard]}, 
    {path: 'results', component: QuizResultsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
