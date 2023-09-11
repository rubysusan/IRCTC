import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TteAccountComponent } from './tte-account.component';

describe('TteAccountComponent', () => {
  let component: TteAccountComponent;
  let fixture: ComponentFixture<TteAccountComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TteAccountComponent]
    });
    fixture = TestBed.createComponent(TteAccountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
