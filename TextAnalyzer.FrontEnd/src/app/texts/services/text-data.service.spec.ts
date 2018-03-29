import { TestBed, inject } from '@angular/core/testing';

import { TextDataService } from './text-data.service';

describe('TextDataService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TextDataService]
    });
  });

  it('should be created', inject([TextDataService], (service: TextDataService) => {
    expect(service).toBeTruthy();
  }));
});
