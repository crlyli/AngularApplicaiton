import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError } from 'rxjs';
import { BookDataModel } from 'src/app/model/book.model';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient) {
  }

  static readonly apiBaseUrl = environment.apiBaseUrl;
  bookdata = []
  getBooks(): Observable<BookDataModel[]> {
    return this.http.get<any[]>(`${BookService.apiBaseUrl}/Books`)
  };

  getBookById(id:string): Observable<BookDataModel[]> {
    return this.http.get<any[]>(`${BookService.apiBaseUrl}/Books`)
  };

  addBook(model: BookDataModel): Observable<void> {
  return this.http.post<void>(`${BookService.apiBaseUrl}/Books`, model)
  };

  deleteBook(id:string): Observable<void> {
    return this.http.delete<void>(`${BookService.apiBaseUrl}/Books` + `/` + id)
    };

}
