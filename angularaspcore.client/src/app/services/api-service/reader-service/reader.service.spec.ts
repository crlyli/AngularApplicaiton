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

  //No request remain outstanding
  afterEach(() => {
    // After every test, assert that there are no more pending requests.
    httpTestingController.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('Should return books from Http Get call.', () => {
    //Act
    service.getReaders()
      .subscribe({
        next: (response) => {
    //Assert
          expect(response).toBeTruthy();
          expect(response.length).toBeGreaterThan(1);
        }
      });
    const mockHttp = httpTestingController.expectOne(`${ReaderService.apiBaseUrl}/Reader`);
    const httpRequest = mockHttp.request;

    expect(httpRequest.method).toEqual("GET");
    expect(mockHttp.cancelled).toBeFalsy();
    expect(mockHttp.request.responseType).toEqual('json');

    mockHttp.flush(READER_RESPONSE);
  });

  it('Should return error message for Blog Http request.', () => {
    //Act
    service.getReaders()
    .subscribe({
        error: (error) => {
    //Assert
          expect(error).toBeTruthy();
          expect(error.status).withContext('status').toEqual(401);
        }
    });

    const mockHttp = httpTestingController.expectOne(`${ReaderService.apiBaseUrl}/Reader`);
    httpTestingController.verify();

    mockHttp.flush("error request", { status: 401, statusText: 'Unathorized access' });
  });

  it('delete should make a DELETE HTTP request with id appended to end of url', () => {
    //Arrange
    const id = '1';

    //Act
    service.deleteReaders(id).subscribe(res => {

    //Assert
      expect(res).toBe(1);
     });

    const mockHttp = httpTestingController.expectOne(`${ReaderService.apiBaseUrl}/Reader/1`, 'delete to api');
    expect(mockHttp.request.method).toBe('DELETE');
    expect(mockHttp.cancelled).toBeFalsy();
    expect(mockHttp.request.responseType).toEqual('json');

    mockHttp.flush(1);
   });


   it('create should make a POST HTTP request with resource as body', () => {
    //Arrange
    const createObj = {
      id:1,
      fullName: "Updated"
    }

    //Act
    service.addReaders(createObj).subscribe(data => {
    //Assert
      expect(data.fullName).toBe(createObj.fullName);
     });

    const req = httpTestingController.expectOne(`${ReaderService.apiBaseUrl}/Reader`, 'post to api');

    expect(req.request.method).toBe('POST');
    expect(req.request.body).toBe(createObj);
    expect(req.cancelled).toBeFalsy();
    expect(req.request.responseType).toEqual('json');

    req.flush(createObj);
    });
});
