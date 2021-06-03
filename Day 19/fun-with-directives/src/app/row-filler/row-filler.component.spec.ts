import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RowFillerComponent } from './row-filler.component';

describe('RowFillerComponent', () => {
  let component: RowFillerComponent;
  let fixture: ComponentFixture<RowFillerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RowFillerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RowFillerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
