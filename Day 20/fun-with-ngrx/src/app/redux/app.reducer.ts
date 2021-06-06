import { createReducer, on } from "@ngrx/store";
import { addAnswer, addQuestion, reset } from "./app.actions";
import { initialAppModel } from "./app.model";

export const appReducer = createReducer(initialAppModel,
    on(reset, (state, action) => ({
        ...state, 
        answers: []
    })), 

    on(addQuestion, (state, action) => ({
        ...state, 
        questions: [...state.questions, action.question]
    })), 

    on(addAnswer, (state, action) => ({
        ...state, 
        answers: [...state.answers, action.answer]
    }))
);