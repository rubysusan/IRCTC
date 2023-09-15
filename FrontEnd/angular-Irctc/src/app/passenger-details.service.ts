import { Injectable } from '@angular/core';
import { IPassenger } from './IPassenger.Interface';
import { BehaviorSubject } from 'rxjs';
import { IPassengerStatus } from './IPassengerStatus.Interface';

@Injectable({
  providedIn: 'root'
})
export class PassengerDetailsService {

  constructor() { }
  public passsengerData=new BehaviorSubject<Array<IPassenger>>([]);
  passenger=this.passsengerData.asObservable();
  
  public passengerStatus=new BehaviorSubject<Array<IPassengerStatus>>([])
  status=this.passengerStatus.asObservable();
  
    setValue(data:Array<IPassenger>)
    {
      this.passsengerData.next(data);
    }
    setStatusValue(data:Array<IPassengerStatus>)
    {
      this.passengerStatus.next(data)
    }
}
