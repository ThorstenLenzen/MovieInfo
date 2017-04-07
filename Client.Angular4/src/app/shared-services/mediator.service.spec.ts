import { TestBed, inject } from '@angular/core/testing';

import { MediatorService } from './mediator.service';

xdescribe('MediatorService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MediatorService]
    });
  });

  it('should ...', inject([MediatorService], (service: MediatorService) => {
    expect(service).toBeTruthy();
  }));
});
