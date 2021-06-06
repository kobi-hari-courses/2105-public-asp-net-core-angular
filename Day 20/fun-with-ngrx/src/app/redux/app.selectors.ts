import { createFeatureSelector, createSelector } from "@ngrx/store";
import { AppModel } from "./app.model";

export const selectApp = createFeatureSelector<AppModel>('app');

export const selectAllQuestions = createSelector(selectApp, state => state.questions);

export const selectAllAnswers = createSelector(selectApp, state => state.answers);

export const selectCurrentIndex = createSelector(selectAllAnswers, answers => answers.length);

export const selectIsQuizDone = createSelector(selectApp, 
    state => state.answers.length >= state.questions.length);

export const selectCurrentQuestion = createSelector(selectAllQuestions, selectCurrentIndex, 
    (all, currentIndex) => all[currentIndex]);