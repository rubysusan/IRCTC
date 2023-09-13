import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TteTrainsComponent } from './tte-trains.component';

describe('TteTrainsComponent', () => {
  let component: TteTrainsComponent;
  let fixture: ComponentFixture<TteTrainsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TteTrainsComponent]
    });
    fixture = TestBed.createComponent(TteTrainsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
