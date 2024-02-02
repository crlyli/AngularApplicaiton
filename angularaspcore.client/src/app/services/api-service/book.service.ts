import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError } from 'rxjs';
import { BookDataModel } from 'src/app/model/book.model';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private http: HttpClient) { 
  }

  apiBaseUrl = environment.apiBaseUrl;
  bookdata = []
  getBooks(): Observable<BookDataModel[]> {
    return this.http.get<any[]>(`${this.apiBaseUrl}/Books`)
  };

  addBook(model: BookDataModel): Observable<void> {
  return this.http.post<void>(`${this.apiBaseUrl}/Books`, model)
  };
  
  deleteBook(id:string): Observable<void> {
    return this.http.delete<void>(`${this.apiBaseUrl}/Books` + `/` + id)
    };

}
