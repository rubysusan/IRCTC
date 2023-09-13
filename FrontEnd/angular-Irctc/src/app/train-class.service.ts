import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

interface ITrainClass{
  trainClassId:number;
}
@Injectable({
  providedIn: 'root'
})
export class TrainClassService {
  private baseURL="https://localhost:7247/api/TrainClass/"

  constructor(private http:HttpClient) { }
  public getTrainClassId(trainId:number,coachId:number):Observable<Array<ITrainClass>>
  {
    let params=new HttpParams();
    params = params.append('TrainId', trainId);
    params = params.append('CoachId', coachId);
    return this.http.get<Array<ITrainClass>>(this.baseURL+'get-train-class-id',{params});
  }
}
