import {
  HttpClient
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ISearchedTrain } from './ISearchedTrain.Interface';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class TraintypeHttpService {
private baseURL="https://localhost:7247/api/TrainSearchByTrainType/";
constructor(private http:HttpClient) { }
public getTrainByType(from:number,to:number,date:string,coach:number,type:string):Observable<Array<ISearchedTrain>>
{
  return this.http.get<Array<ISearchedTrain>>(`${this.baseURL}TrainSearchByTrainType?FromStationName=${from}&ToStationName=${to}&Date=${date}&CoachName=${coach}&TypeName=${type}`);
}
}
