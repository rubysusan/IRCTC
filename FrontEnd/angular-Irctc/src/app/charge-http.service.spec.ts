import { TestBed } from '@angular/core/testing';

import { ChargeHttpService } from './charge-http.service';

describe('ChargeHttpService', () => {
  let service: ChargeHttpService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ChargeHttpService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
