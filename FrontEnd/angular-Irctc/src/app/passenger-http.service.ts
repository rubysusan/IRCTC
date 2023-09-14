import { HttpClient, HttpParams} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPassengerTTE } from './IPassengerTTE.Interface';
import { IPassengerInsert } from './IPassengerInsert.Interface';

@Injectable({
  providedIn: 'root'
})
export class PassengerHttpService {
  private baseURL="https://localhost:7247/api/Passenger/"

  constructor(private http:HttpClient) { }
  public addPassenger(pass:IPassengerInsert ):Observable<IPassengerInsert>
  {
    return this.http.put<IPassengerInsert>(this.baseURL+"add",pass);
  }

  public getPassenger(trainId:number):Observable<Array<IPassengerTTE>>
  {
    let params=new HttpParams()
    params=params.append('TrainId',trainId)
    return this.http.get<Array<IPassengerTTE>>(this.baseURL+"get-for-tte",{params})

  }
}
