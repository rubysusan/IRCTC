import { TestBed } from '@angular/core/testing';

import { StationHttpService } from './station-http.service';

describe('StationHttpService', () => {
  let service: StationHttpService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StationHttpService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
