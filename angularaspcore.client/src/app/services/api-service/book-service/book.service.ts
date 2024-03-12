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

  addBook(model: BookDataModel): Observable<BookDataModel> {
  return this.http.post<BookDataModel>(`${BookService.apiBaseUrl}/Books`, model)
  };

  deleteBook(id:string): Observable<number> {
    return this.http.delete<number>(`${BookService.apiBaseUrl}/Books` + `/` + id)
    };

}
