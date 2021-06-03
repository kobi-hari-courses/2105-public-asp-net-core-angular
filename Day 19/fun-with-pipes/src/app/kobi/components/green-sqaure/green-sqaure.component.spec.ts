import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GreenSqaureComponent } from './green-sqaure.component';

describe('GreenSqaureComponent', () => {
  let component: GreenSqaureComponent;
  let fixture: ComponentFixture<GreenSqaureComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GreenSqaureComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GreenSqaureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
