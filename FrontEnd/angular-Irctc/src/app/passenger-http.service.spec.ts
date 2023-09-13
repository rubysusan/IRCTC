import { TestBed } from '@angular/core/testing';

import { PassengerHttpService } from './passenger-http.service';

describe('PassengerHttpService', () => {
  let service: PassengerHttpService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PassengerHttpService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
