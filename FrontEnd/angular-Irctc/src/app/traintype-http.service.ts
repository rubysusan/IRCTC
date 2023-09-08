import {
  HttpClient, HttpParams
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
public getTrainByType(from:number,to:number,date:string,coach:number,type:number):Observable<Array<ISearchedTrain>>
{
  let params=new HttpParams();
  params = params.append('FromStationId', from);
  params = params.append('ToStationId', to);
  params = params.append('Date', date);
  params = params.append('CoachId', coach);
  params = params.append('TypeId', type);
  return this.http.get<Array<ISearchedTrain>>(this.baseURL+'get',{params});
}
}
