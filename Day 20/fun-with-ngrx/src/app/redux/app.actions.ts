import { createAction, props } from "@ngrx/store";
import { Question } from "../models/question.model";

export const reset = createAction('[User] Reset');

export const addQuestion = createAction('[User] Add Question', props<{question: Question}>());

export const addAnswer = createAction('[User] Add Answer', props<{answer: number}>());