import { HttpClient, HttpParams} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ISeatDetails } from './ISeatDetails.Interface';
import { Observable } from 'rxjs';
import { ISeatForPassenger } from './ISeatForPassenger.Interface';

@Injectable({
  providedIn: 'root'
})
export class SeatHttpService {

    private baseURL="https://localhost:7247/api/AvailableSeats/"
  
    constructor(private http:HttpClient) { }
    public getSeats(id:number):Observable<Array<ISeatDetails>>
    {
      let params=new HttpParams();
  params = params.append('TrainId', id);
      return this.http.get<Array<ISeatDetails>>(this.baseURL+'get',{params});
    }
    public getSeatForPassenger(type:number,coach:number):Observable<Array<ISeatForPassenger>>
    {
      let params=new HttpParams();
  params = params.append('SeatTypeId', type);
  params = params.append('TrainClassId', coach);
  return this.http.get<Array<ISeatForPassenger>>(this.baseURL+'get-seat-for-passenger',{params});
    }
  }
  

