import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IUpdateSeat } from './IUpdateSeat.Interface';

@Injectable({
  providedIn: 'root'
})
export class SeatService {

  private baseURL="https://localhost:7247/api/Seat/"
  
    constructor(private http:HttpClient) { }
    public updateSeats(seatId:IUpdateSeat):Observable<Array<IUpdateSeat>>
      
    {

      return this.http.put<Array<IUpdateSeat>>(this.baseURL+'update',seatId);
    }
  
}
