import { TestBed } from '@angular/core/testing';

import { QuizOverGuard } from './quiz-over.guard';

describe('QuizOverGuard', () => {
  let guard: QuizOverGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(QuizOverGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
