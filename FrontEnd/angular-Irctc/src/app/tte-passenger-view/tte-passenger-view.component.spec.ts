import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TtePassengerViewComponent } from './tte-passenger-view.component';

describe('TtePassengerViewComponent', () => {
  let component: TtePassengerViewComponent;
  let fixture: ComponentFixture<TtePassengerViewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TtePassengerViewComponent]
    });
    fixture = TestBed.createComponent(TtePassengerViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
