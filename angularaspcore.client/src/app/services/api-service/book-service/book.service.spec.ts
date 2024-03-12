import { TestBed } from '@angular/core/testing';
// Http testing module and mocking controller
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { BookService } from './book.service';

describe('BookService', () => {
  let service: BookService;
  let httpTestingController: HttpTestingController;

  const BOOK_RESPONSE = [
    {
      id:1,
      title: 'A Book Title',
      description: 'A book description',
      author: 'First Last'
    },
    {
      id:2,
      title: 'A Book Title Two',
      description: 'A book description two',
      author: 'FirstTwo LastTwo'
    }
  ];

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [BookService]
    });
    service = TestBed.inject(BookService);
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
    service.getBooks()
      .subscribe({
        next: (response) => {
    //Assert
          expect(response).toBeTruthy();
          expect(response.length).toBeGreaterThan(1);
          expect(response).toEqual(BOOK_RESPONSE)
        }
      });
    const mockHttp = httpTestingController.expectOne(`${BookService.apiBaseUrl}/Books`);
    const httpRequest = mockHttp.request;

    expect(httpRequest.method).toEqual("GET");

    mockHttp.flush(BOOK_RESPONSE);
  });

  it('Should return error message for Blog Http request.', () => {

    //Act
    service.getBooks()
    .subscribe({
        error: (error) => {
    //Assert
          expect(error).toBeTruthy();
          expect(error.status).withContext('status').toEqual(401);
        }
    });

    const mockHttp = httpTestingController.expectOne(`${BookService.apiBaseUrl}/Books`);
    mockHttp.flush("error request", { status: 401, statusText: 'Unathorized access' });
  });

  it('delete should make a DELETE HTTP request with id appended to end of url', () => {
    //Arrange
    const id = '1';

    //Act
    service.deleteBook(id).subscribe(res => {

    //Assert
      expect(res).toBe(1);
     });

    const mockHttp = httpTestingController.expectOne(`${BookService.apiBaseUrl}/Books/1`, 'delete to api');
    expect(mockHttp.request.method).toBe('DELETE');
    expect(mockHttp.cancelled).toBeFalsy();
    expect(mockHttp.request.responseType).toEqual('json');
    mockHttp.flush(1);
   });

   it('create should make a POST HTTP request with resource as body', () => {
    //Arrange
    const createObj = {
      id:3,
      title: 'A Book Title Three',
      description: 'A book description Three',
      author: 'First Three'
    }

    //Act
    service.addBook(createObj).subscribe(data => {
    //Assert
      expect(data.title).toBe(createObj.title);
     });

    const req = httpTestingController.expectOne(`${BookService.apiBaseUrl}/Books`, 'post to api');

    expect(req.request.method).toBe('POST');
    expect(req.request.body).toBe(createObj);
    expect(req.cancelled).toBeFalsy();
    expect(req.request.responseType).toEqual('json');

    req.flush(createObj);
    });
});
