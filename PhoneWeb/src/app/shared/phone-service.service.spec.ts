/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PhoneServiceService } from './phone-service.service';

describe('Service: PhoneService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PhoneServiceService]
    });
  });

  it('should ...', inject([PhoneServiceService], (service: PhoneServiceService) => {
    expect(service).toBeTruthy();
  }));
});
