import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { Question } from 'src/app/models/question.model';
import { addQuestion } from 'src/app/redux/app.actions';

@Component({
    selector: 'app-add-question',
    templateUrl: './add-question.component.html',
    styleUrls: ['./add-question.component.css']
})
export class AddQuestionComponent implements OnInit {
    form!: FormGroup;

    constructor(private store: Store<any>) { }

    ngOnInit(): void {
        this.buildForm();
    }

    buildForm() {
        this.form = new FormGroup({
            caption: new FormControl('', Validators.required),
            answers: new FormControl('', Validators.required),
            correctAnswer: new FormControl(0, Validators.required)
        });
    }

    add() {
        if (this.form.valid) {
            const formValue = this.form.value;
            const question: Question = {
                caption: (formValue.caption as string), 
                answers: (formValue.answers as string).split(',').map(q => q.trim()),
                correctAnswer: (formValue.correctAnswer as number)
            }

            this.store.dispatch(addQuestion({question}));
        }
    }

}
