import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddBookRequest } from 'src/app/model/add-book-reqeust.model';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private http: HttpClient) { 
  }

  apiBaseUrl = environment.apiBaseUrl;
  getPosts(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiBaseUrl}/controller/books`);
}
addBook(model: AddBookRequest): Observable<void> {
  debugger;
  return this.http.post<void>(`${this.apiBaseUrl}/Books`, model)
  }
}
