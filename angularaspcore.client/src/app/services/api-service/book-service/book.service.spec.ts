import { TestBed } from '@angular/core/testing';
// Http testing module and mocking controller
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
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

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('Should return books from Http Get call.', () => {
    service.getBooks()
      .subscribe({
        next: (response) => {
          expect(response).toBeTruthy();
          expect(response.length).toBeGreaterThan(1);
        }
      });
    const mockHttp = httpTestingController.expectOne(`${BookService.apiBaseUrl}/Books`);
    const httpRequest = mockHttp.request;

    expect(httpRequest.method).toEqual("GET");

    mockHttp.flush(BOOK_RESPONSE);
  });

  it('Should return error message for Blog Http request.', () => {
    service.getBooks()
    .subscribe({
        error: (error) => {
          expect(error).toBeTruthy();
          expect(error.status).withContext('status').toEqual(401);
        }
    });

    const mockHttp = httpTestingController.expectOne(`${BookService.apiBaseUrl}/Books`);
    httpTestingController.verify();

    mockHttp.flush("error request", { status: 401, statusText: 'Unathorized access' });
  });
});
