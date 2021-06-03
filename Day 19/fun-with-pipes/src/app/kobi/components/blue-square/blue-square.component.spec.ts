import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BlueSquareComponent } from './blue-square.component';

describe('BlueSquareComponent', () => {
  let component: BlueSquareComponent;
  let fixture: ComponentFixture<BlueSquareComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BlueSquareComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BlueSquareComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
