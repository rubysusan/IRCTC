import {
  HttpClient
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ISearchedTrain } from './ISearchedTrain.Interface';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TrainsSearchHttpService {
  private baseURL="https://localhost:7247/api/TrainSearch/";
  constructor(private http:HttpClient) { }
  public getTrainBySearch(from:number,to:number,date:string,coach:number):Observable<Array<ISearchedTrain>>
  {
    return this.http.get<Array<ISearchedTrain>>(`${this.baseURL}get?FromStationId=${from}&ToStationId=${to}&Date=${date}&CoachId=${coach}`);
  }
}
