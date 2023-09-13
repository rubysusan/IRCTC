import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TteSearchComponent } from './tte-search.component';

describe('TteSearchComponent', () => {
  let component: TteSearchComponent;
  let fixture: ComponentFixture<TteSearchComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TteSearchComponent]
    });
    fixture = TestBed.createComponent(TteSearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
