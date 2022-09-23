/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { GastoService } from './gasto.service';

describe('Service: Gasto', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [GastoService]
    });
  });

  it('should ...', inject([GastoService], (service: GastoService) => {
    expect(service).toBeTruthy();
  }));
});
