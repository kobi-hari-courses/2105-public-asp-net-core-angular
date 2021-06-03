import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CombinedSqaureComponent } from './combined-sqaure.component';

describe('CombinedSqaureComponent', () => {
  let component: CombinedSqaureComponent;
  let fixture: ComponentFixture<CombinedSqaureComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CombinedSqaureComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CombinedSqaureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
