import { HttpClient, HttpParams} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { IPassengerTTE } from './IPassengerTTE.Interface';
import { IPassengerInsert } from './IPassengerInsert.Interface';
interface IPassengerId{
  id:number
}
@Injectable({
  providedIn: 'root'
})
export class PassengerHttpService {
  
  private baseURL="https://localhost:7247/api/Passenger/"

  constructor(private http:HttpClient) { }
  public addPassenger(pass:IPassengerInsert ):Observable<IPassengerInsert>
  {
    return this.http.post<IPassengerInsert>(this.baseURL+"add",pass);
  }

  public getPassenger(trainId:number):Observable<Array<IPassengerTTE>>
  {
    let params=new HttpParams()
    params=params.append('TrainId',trainId)
    return this.http.get<Array<IPassengerTTE>>(this.baseURL+"get-for-tte",{params})

  }
  public updatePassenger(id:IPassengerId):Observable<boolean>
  {
    return this.http.put<boolean>(this.baseURL+"update-passenger",id)
  }
  public train=new BehaviorSubject<number>(0);
  trainId=this.train.asObservable();
  
  
    setValue(data:number)
    {
      this.train.next(data);
    }
}
