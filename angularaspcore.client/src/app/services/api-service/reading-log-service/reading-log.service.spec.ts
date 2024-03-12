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
        description: "A book description",
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
        description: "A book description Two",
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

  //No request remain outstanding
  afterEach(() => {
    // After every test, assert that there are no more pending requests.
    httpTestingController.verify();
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

  it('delete should make a DELETE HTTP request with id appended to end of url', () => {
    //Arrange
    const id = '1';

    //Act
    service.deletereadinglog(id).subscribe(res => {

    //Assert
      expect(res).toBe(1);
     });

    const mockHttp = httpTestingController.expectOne(`${ReadingLogService.apiBaseUrl}/ReadingLog/1`, 'delete to api');
    expect(mockHttp.request.method).toBe('DELETE');
    expect(mockHttp.cancelled).toBeFalsy();
    expect(mockHttp.request.responseType).toEqual('json');
    mockHttp.flush(1);
   });

   it('create should make a POST HTTP request with resource as body', () => {
    //Arrange
    const createObj = {
      readerId: {
        id: 2,
        fullName: "FirstTwo LastTwo"
      },
      bookId: {
        id:1,
        title: "A Book Title Two",
        description: "A book description Two",
        author: "FirstTwo LastTwo"
      },
      ReadingStart: new Date().toString(),
      ReadingEnd: undefined
    }

    //Act
    service.addreadinglog(createObj).subscribe(data => {
    //Assert
      expect(data.readerId.fullName).toBe(createObj.readerId.fullName);
     });

    const req = httpTestingController.expectOne(`${ReadingLogService.apiBaseUrl}/ReadingLog`, 'post to api');

    expect(req.request.method).toBe('POST');
    expect(req.request.body).toBe(createObj);
    expect(req.cancelled).toBeFalsy();
    expect(req.request.responseType).toEqual('json');

    req.flush(createObj);
    });
});
