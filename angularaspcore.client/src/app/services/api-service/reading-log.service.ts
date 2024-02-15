import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError } from 'rxjs';
import { BookDataModel } from 'src/app/model/book.model';
import { ReadingLogDataModel } from 'src/app/model/reading_log.model';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ReadingLogService {

  constructor(private http: HttpClient) { 
  }

  apiBaseUrl = environment.apiBaseUrl;
  bookdata = []
  getreadinglog(): Observable<ReadingLogDataModel> {
    return this.http.get<any>(`${this.apiBaseUrl}/ReadingLog`)
  };
  getreadinglogs(): Observable<ReadingLogDataModel[]> {
    return this.http.get<any[]>(`${this.apiBaseUrl}/ReadingLog`)
  };

  addreadinglog(model: ReadingLogDataModel): Observable<void> {
  return this.http.post<void>(`${this.apiBaseUrl}/ReadingLog`, model)
  };
  
  deletereadinglog(id:string): Observable<void> {
    return this.http.delete<void>(`${this.apiBaseUrl}/ReadingLog` + `/` + id)
    };

}