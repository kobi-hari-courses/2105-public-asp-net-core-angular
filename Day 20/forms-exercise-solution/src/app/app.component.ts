import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Movie } from './models/movie.model';
import { urlValidator, wordsValidator } from './validations/general-validators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
    form!: FormGroup;

    ngOnInit(): void {
        this.buildForm();
    }

    buildForm() {
        this.form = new FormGroup({
            name: new FormControl('', [Validators.required]), 
            description: new FormControl('', [Validators.required, wordsValidator(10)]), 
            poster: new FormControl('', [Validators.required, urlValidator])
        });

        let initialMovie: Movie = {
            name: 'E.T.', 
            description: 'A friend from another world', 
            poster: 'http://blabla.images.com/et'
        }

        this.form.reset(initialMovie);
    }

    onGo() {
        let originalMovie: Movie = {
            id: 12, 
            name: 'bla', 
            description: 'bla bla bla', 
            poster: ''
        }

        originalMovie = {
            ...originalMovie, 
            ...this.form.value
        }

        console.log(this.form.value);
    }

    get(fieldName: string) {
        return this.form.get(fieldName);
    }
}
