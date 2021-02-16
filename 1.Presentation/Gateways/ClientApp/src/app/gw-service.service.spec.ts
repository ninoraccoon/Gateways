import { TestBed } from '@angular/core/testing';

import { GwServiceService } from './gw-service.service';

describe('GwServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: GwServiceService = TestBed.get(GwServiceService);
    expect(service).toBeTruthy();
  });
});
