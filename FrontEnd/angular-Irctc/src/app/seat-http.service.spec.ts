import { TestBed } from '@angular/core/testing';

import { SeatHttpService } from './seat-http.service';

describe('SeatHttpService', () => {
  let service: SeatHttpService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SeatHttpService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
