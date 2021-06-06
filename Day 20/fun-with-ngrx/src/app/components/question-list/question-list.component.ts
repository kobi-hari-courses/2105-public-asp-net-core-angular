import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Question } from 'src/app/models/question.model';
import { selectAllQuestions } from 'src/app/redux/app.selectors';

@Component({
  selector: 'app-question-list',
  templateUrl: './question-list.component.html',
  styleUrls: ['./question-list.component.css']
})
export class QuestionListComponent implements OnInit {
    questions$!: Observable<Question[]>

  constructor(private store: Store<any>, private router: Router) { }

  ngOnInit(): void {
      this.questions$ = this.store.select(selectAllQuestions);
  }

  gotoQuestion(index: number) {
      this.router.navigate(['questions', 'view', index]);
  }

}
