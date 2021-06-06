import { createFeatureSelector, createSelector } from "@ngrx/store";
import { AppModel } from "./app.model";

export const selectApp = createFeatureSelector<AppModel>('app');

export const selectAllQuestions = createSelector(selectApp, state => state.questions);
