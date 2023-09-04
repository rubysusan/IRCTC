import { HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IStationDetails } from './IStationDetails.Interface';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StationHttpService {
  private baseURL="https://localhost:7247/api/Station/"

  constructor(private http:HttpClient) { }
  public getStation():Observable<Array<IStationDetails>>
  {
    return this.http.get<Array<IStationDetails>>(this.baseURL+"GetAllStation");
  }
}
