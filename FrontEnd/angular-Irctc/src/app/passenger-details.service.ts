import { Injectable } from '@angular/core';
import { IPassenger } from './IPassenger.Interface';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PassengerDetailsService {

  constructor() { }
  public passsengerData=new BehaviorSubject<Array<IPassenger>>([]);
  passenger=this.passsengerData.asObservable();
  
  
    setValue(data:Array<IPassenger>)
    {
      this.passsengerData.next(data);
    }
}
