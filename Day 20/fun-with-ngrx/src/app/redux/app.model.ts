import { Question } from "../models/question.model";

export interface AppModel {
    readonly questions: Question[];
    readonly answers: number[];
}

export const initialAppModel: AppModel = {
    questions: [
        {
            caption: 'How much is 2 + 2', 
            answers: ['4', '5' ,'6', '7'], 
            correctAnswer: 0
        }, 
        {
            caption: 'How much is 2 + 3', 
            answers: ['4', '5' ,'6', '7'], 
            correctAnswer: 1
        }, 
        {
            caption: 'How much is 2 + 5', 
            answers: ['4', '5' ,'6', '7'], 
            correctAnswer: 3
        }, 
    ], 
    answers: []
}