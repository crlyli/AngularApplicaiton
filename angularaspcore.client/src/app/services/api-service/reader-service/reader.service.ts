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

  addReaders(model: ReaderDataModel): Observable<ReaderDataModel> {
  return this.http.post<ReaderDataModel>(`${ReaderService.apiBaseUrl}/Reader`, model)
  };

  deleteReaders(id:string): Observable<number> {
    return this.http.delete<number>(`${ReaderService.apiBaseUrl}/Reader` + `/` + id)
    };

}
