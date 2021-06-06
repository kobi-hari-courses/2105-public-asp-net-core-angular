import { createReducer, on } from "@ngrx/store";
import { addQuestion, reset } from "./app.actions";
import { initialAppModel } from "./app.model";

export const appReducer = createReducer(initialAppModel,
    on(reset, (state, action) => ({
        questions: []
    })), 

    on(addQuestion, (state, action) => ({
        ...state, 
        questions: [...state.questions, action.question]
    }))
);