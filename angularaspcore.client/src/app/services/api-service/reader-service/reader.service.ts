import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError } from 'rxjs';
import { ReaderDataModel } from 'src/app/model/reader.model';
import { environment } from 'src/environments/environment.development';
import { map } from 'rxjs';
export interface FoodListModelServerResponse {
    readers: ReaderDataModel[];
    }

@Injectable({
  providedIn: 'root'
})
export class ReaderService {

  constructor(private http: HttpClient) {
  }

  static readonly apiBaseUrl = environment.apiBaseUrl;
  readerdata = []
  getReaders(): Observable<ReaderDataModel[]> {
    return this.http.get<ReaderDataModel[]>(`${ReaderService.apiBaseUrl}/Reader`)
  };

  addReaders(model: ReaderDataModel): Observable<void> {
  return this.http.post<void>(`${ReaderService.apiBaseUrl}/Reader`, model)
  };

  deleteReaders(id:string): Observable<void> {
    return this.http.delete<void>(`${ReaderService.apiBaseUrl}/Reader` + `/` + id)
    };

}
