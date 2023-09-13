import { TestBed } from '@angular/core/testing';

import { TrainClassService } from './train-class.service';

describe('TrainClassService', () => {
  let service: TrainClassService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TrainClassService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
