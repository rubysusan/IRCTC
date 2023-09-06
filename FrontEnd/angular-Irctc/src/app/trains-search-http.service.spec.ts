import { TestBed } from '@angular/core/testing';

import { TrainsSearchHttpService } from './trains-search-http.service';

describe('TrainsSearchHttpService', () => {
  let service: TrainsSearchHttpService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TrainsSearchHttpService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
