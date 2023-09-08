import { HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

interface IChargeValue{
  charge:number;
}
@Injectable({
  providedIn: 'root'
})
export class ChargeHttpService {
//GetCharge?TrainId=4&FromStation=Varkala&ToStation=Kollam%20Junction&CoachName=ACChairCar
private baseURL="https://localhost:7247/api/GetCharge/"
constructor(private http:HttpClient) { }
public getCharge(id:number,from:number,to:number,coach:number):Observable<Array<IChargeValue>>{
  return this.http.get<Array<IChargeValue>>(`${this.baseURL}GetCharge?TrainId=${id}&FromStation=${from}&ToStation=${to}&CoachName=${coach}`);
}

}
