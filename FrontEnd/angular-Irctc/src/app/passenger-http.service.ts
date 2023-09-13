import { HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPassengerTTE } from './IPassengerTTE.Interface';

@Injectable({
  providedIn: 'root'
})
export class PassengerHttpService {
  private baseURL="https://localhost:7247/api/Passenger/"

  constructor(private http:HttpClient) { }
  public addPassenger(pass:IPassengerTTE ):Observable<IPassengerTTE>
  {
    return this.http.put<IPassengerTTE>(this.baseURL+"add",pass);
  }
}
