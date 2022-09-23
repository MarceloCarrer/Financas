/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ParceladoService } from './parcelado.service';

describe('Service: Parcelado', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ParceladoService]
    });
  });

  it('should ...', inject([ParceladoService], (service: ParceladoService) => {
    expect(service).toBeTruthy();
  }));
});
