import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RedSquareComponent } from './red-square.component';

describe('RedSquareComponent', () => {
  let component: RedSquareComponent;
  let fixture: ComponentFixture<RedSquareComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RedSquareComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RedSquareComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
