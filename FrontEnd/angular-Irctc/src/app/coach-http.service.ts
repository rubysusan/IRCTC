import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICoachDetails } from './ICoachDetails.Interface';

@Injectable({
  providedIn: 'root'
})
export class CoachHttpService {
  private baseURL="https://localhost:7247/api/Coach/"
  constructor(private http:HttpClient) { }
  public getCoach():Observable<Array<ICoachDetails>>{
    return this.http.get<Array<ICoachDetails>>(this.baseURL+"GetAllCoach");
  }
  
}
