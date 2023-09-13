import { TestBed } from '@angular/core/testing';

import { AvailableSeatHttpService } from './available-seat-http.service';

describe('SeatHttpService', () => {
  let service: AvailableSeatHttpService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AvailableSeatHttpService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
