import { TestBed } from '@angular/core/testing';

import { CancelHttpService } from './cancel-http.service';

describe('CancelHttpService', () => {
  let service: CancelHttpService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CancelHttpService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
