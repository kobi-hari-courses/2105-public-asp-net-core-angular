import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddQuestionComponent } from './components/add-question/add-question.component';
import { QuestionDetailsComponent } from './components/question-details/question-details.component';
import { QuestionListComponent } from './components/question-list/question-list.component';

const routes: Routes = [
    {path: 'questions', component: QuestionListComponent}, 
    {path: 'questions/add', component: AddQuestionComponent }, 
    {path: 'questions/view/:index', component: QuestionDetailsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
