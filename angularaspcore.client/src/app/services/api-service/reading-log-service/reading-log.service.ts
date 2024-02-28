import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError } from 'rxjs';
import { ReadingLogDataModel } from 'src/app/model/reading_log.model';
import { ReadingLogDtoModel } from 'src/app/model/reading_log_dto.model';
import { environment } from 'src/environments/environment.development';
import { ReaderService } from '../reader-service/reader.service';

@Injectable({
  providedIn: 'root'
})
export class ReadingLogService {

  constructor(private http: HttpClient) {
  }

  static readonly apiBaseUrl = environment.apiBaseUrl;
  bookdata = []
  getreadinglog(): Observable<ReadingLogDataModel> {
    return this.http.get<any>(`${ReaderService.apiBaseUrl}/ReadingLog`)
  };
  getreadinglogs(): Observable<ReadingLogDataModel[]> {
    return this.http.get<any[]>(`${ReaderService.apiBaseUrl}/ReadingLog`)
  };

  addreadinglog(model: ReadingLogDtoModel): Observable<void> {
    debugger;
  return this.http.post<void>(`${ReaderService.apiBaseUrl}/ReadingLog`, model)
  };

  deletereadinglog(id:string): Observable<void> {
    return this.http.delete<void>(`${ReaderService.apiBaseUrl}/ReadingLog` + `/` + id)
    };

}
