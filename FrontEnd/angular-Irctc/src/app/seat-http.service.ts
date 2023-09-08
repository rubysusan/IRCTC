import { HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ISeatDetails } from './ISeatDetails.Interface';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SeatHttpService {

    private baseURL="https://localhost:7247/api/AvailableSeats/"
  
    constructor(private http:HttpClient) { }
    public getSeats(id:number):Observable<Array<ISeatDetails>>
    {
      return this.http.get<Array<ISeatDetails>>(`${this.baseURL}get?TrainId=${id}`);
    }
  }
  

