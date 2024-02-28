import { TestBed } from '@angular/core/testing';
// Http testing module and mocking controller
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { ReaderService } from './reader.service';

describe('ReaderService', () => {
  let service: ReaderService;
  let httpTestingController: HttpTestingController;

  const READER_RESPONSE = [
    {
      id:1,
      fullname: "First Last"
    },
    {
      id:2,
      fullname: "FirstTwo LastTwo"
    }
  ];

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [ReaderService]
    });
    service = TestBed.inject(ReaderService);
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('Should return books from Http Get call.', () => {
    service.getReaders()
      .subscribe({
        next: (response) => {
          expect(response).toBeTruthy();
          expect(response.length).toBeGreaterThan(1);
        }
      });
    const mockHttp = httpTestingController.expectOne(`${ReaderService.apiBaseUrl}/Reader`);
    const httpRequest = mockHttp.request;

    expect(httpRequest.method).toEqual("GET");

    mockHttp.flush(READER_RESPONSE);
  });

  it('Should return error message for Blog Http request.', () => {
    service.getReaders()
    .subscribe({
        error: (error) => {
          expect(error).toBeTruthy();
          expect(error.status).withContext('status').toEqual(401);
        }
    });

    const mockHttp = httpTestingController.expectOne(`${ReaderService.apiBaseUrl}/Reader`);
    httpTestingController.verify();

    mockHttp.flush("error request", { status: 401, statusText: 'Unathorized access' });
  });
});
