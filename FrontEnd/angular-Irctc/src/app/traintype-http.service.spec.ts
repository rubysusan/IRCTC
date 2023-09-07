import { TestBed } from '@angular/core/testing';

import { TraintypeHttpService } from './traintype-http.service';

describe('TraintypeHttpService', () => {
  let service: TraintypeHttpService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TraintypeHttpService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
