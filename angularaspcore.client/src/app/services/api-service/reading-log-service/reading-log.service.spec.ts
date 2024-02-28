import { TestBed } from '@angular/core/testing';
// Http testing module and mocking controller
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { ReadingLogService } from './reading-log.service';

describe('ReadingLogService', () => {
  let service: ReadingLogService;
  let httpTestingController: HttpTestingController;

  const READINGLOG_RESPONSE = [

    {
      reader_id: {
        id: 1,
        fullName: "First Last"
      },
      book_id: {
        id:1,
        title: "A Book Title",
        decription: "A book description",
        author: "First Last"
      },
      reading_start: new Date()
    },
    {
      reader_id: {
        id: 2,
        fullName: "FirstTwo LastTwo"
      },
      book_id: {
        id:1,
        title: "A Book Title Two",
        decription: "A book description Two",
        author: "FirstTwo LastTwo"
      },
      reading_start: new Date()
    },
  ];

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [ReadingLogService]
    });
    service = TestBed.inject(ReadingLogService);
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('Should return reading log from Http Get call.', () => {
    service.getreadinglogs()
      .subscribe({
        next: (response) => {
          expect(response).toBeTruthy();
          expect(response.length).toBeGreaterThan(1);
        }
      });
    const mockHttp = httpTestingController.expectOne(`${ReadingLogService.apiBaseUrl}/ReadingLog`);
    const httpRequest = mockHttp.request;

    expect(httpRequest.method).toEqual("GET");

    mockHttp.flush(READINGLOG_RESPONSE);
  });

  it('Should return error message for reading log Http request.', () => {
    service.getreadinglogs()
    .subscribe({
        error: (error) => {
          expect(error).toBeTruthy();
          expect(error.status).withContext('status').toEqual(401);
        }
    });

    const mockHttp = httpTestingController.expectOne(`${ReadingLogService.apiBaseUrl}/ReadingLog`);
    httpTestingController.verify();

    mockHttp.flush("error request", { status: 401, statusText: 'Unathorized access' });
  });
});
