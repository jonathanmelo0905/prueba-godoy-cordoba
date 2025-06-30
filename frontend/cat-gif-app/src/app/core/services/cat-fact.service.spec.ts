import { TestBed } from '@angular/core/testing';

import { CatFactService } from './cat-fact.service';

describe('CatFactService', () => {
  let service: CatFactService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CatFactService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
