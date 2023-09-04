import { TestBed } from '@angular/core/testing';

import { CoachHttpService } from './coach-http.service';

describe('CoachHttpService', () => {
  let service: CoachHttpService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CoachHttpService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
