import { HttpClient, HttpParams} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

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
  let params=new HttpParams();
  params = params.append('TrainId', id);
  params = params.append('FromStationId', from);
  params = params.append('ToStationId', to);
  params = params.append('CoachId', coach);
  return this.http.get<Array<IChargeValue>>(this.baseURL+'get',{params});
}
public chargeValue=new BehaviorSubject<Array<IChargeValue>>([]);
  charge=this.chargeValue.asObservable();
  
  
    setChargeValue(data:Array<IChargeValue>)
    {
      this.chargeValue.next(data);
    }

}
