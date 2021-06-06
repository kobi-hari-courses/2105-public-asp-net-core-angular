import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Store } from '@ngrx/store';
import { selectAllQuestions } from 'src/app/redux/app.selectors';
import { map } from 'rxjs/operators';
import { combineLatest, Observable } from 'rxjs';
import { Question } from 'src/app/models/question.model';

@Component({
  selector: 'app-question-details',
  templateUrl: './question-details.component.html',
  styleUrls: ['./question-details.component.css']
})
export class QuestionDetailsComponent implements OnInit {
    question$!: Observable<Question>;

  constructor(
      private store: Store<any>, 
      private route: ActivatedRoute) { }

  ngOnInit(): void {
      let allQuestions$ = this.store.select(selectAllQuestions);
      let index$ = this.route.params.pipe(
          map(prms => Number(prms['index']))
      );

      this.question$ = combineLatest([allQuestions$, index$]).pipe(
          map(([all, index]) => all[index])
      );

  }

}
