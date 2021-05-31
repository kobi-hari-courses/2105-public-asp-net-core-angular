import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ColorPresenterComponent } from './color-presenter.component';

describe('ColorPresenterComponent', () => {
  let component: ColorPresenterComponent;
  let fixture: ComponentFixture<ColorPresenterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ColorPresenterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ColorPresenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
