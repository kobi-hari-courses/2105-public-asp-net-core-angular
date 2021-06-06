import { AbstractControl, ValidationErrors } from "@angular/forms";

export function urlValidator(control: AbstractControl): null | ValidationErrors {
    if (!control) return null;
    if (!control.value) return null;
    if (typeof(control.value) !== 'string') return null;

    let success = control.value.startsWith(`http://`) 
            || control.value.startsWith(`https://`);

    if (success) return null;

    return {
        'url': true
    };
}

export function wordsValidator(minWords: number): (control: AbstractControl) => null | ValidationErrors {
    return (control: AbstractControl) => {
        if (!control) return null;
        if (!control.value) return null;
        if (typeof(control.value) !== 'string') return null;
    
        let words = control.value
            .split(' ')
            .filter(word => word);
    
        if (words.length >= minWords) return null;
    
        return {
            'words': {
                actual: words.length, 
                minimum: minWords
            }
        }    
    }
}