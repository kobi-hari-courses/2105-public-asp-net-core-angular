import { Question } from "./question";

export class Exam {
    private questions: Question[] = [];
    
    addQuestion(question: Question): void {
        this.questions.push(question);
    }

    print(): void {
        for (const question of this.questions) {
            console.log(question.caption);
            for (const answer of question.answers) {
                console.log(answer);
            }

            console.log('------------------------------');
        }
    }

    grade(answers: number[]): number {
        let totalCorrect = 0;

        for (let i = 0; i < answers.length; i++) {
            let question = this.questions[i];
            let answer = answers[i];

            if (typeof(question) !== 'undefined') {
                if (answer === question.correctIndex) totalCorrect++;
            }
        }

        return totalCorrect / this.questions.length * 100;
    }

}