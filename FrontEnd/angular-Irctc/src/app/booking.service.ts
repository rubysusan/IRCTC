import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { IBooking } from './IBooking.Interface';
import { IBookingData } from './IBookingData.Interface';
import { IBookingHistory } from './IBookingHistory.Interface';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  public bookingData=new BehaviorSubject<IBookingData>({ trainClassId:0,
    fromStop:0,
    toStop:0,
    count:0,
    totalCost:0,
    userId:0,
    bookingStatusId:0});
  newBooking=this.bookingData.asObservable();
  
  
    setValue(data:IBookingData)
    {
      this.bookingData.next(data);
    }
  private baseURL="https://localhost:7247/api/Booking/"
  constructor(private http:HttpClient) { }

  public getBookingDetails():Observable<Array<IBooking>>
  {
    return this.http.get<Array<IBooking>>(this.baseURL+"get");
  }
  public addBookingDetails(booking:IBookingData):Observable<IBookingData>
  {
    return this.http.post<IBookingData>(this.baseURL+"add",booking);
  }
  public getPastBooking(id:number):Observable<Array<IBookingHistory>>
  {
    let params= new HttpParams()
    params=params.append('UserId',id)
    return this.http.get<Array<IBookingHistory>>(this.baseURL+"get-past",{params})
  }
  public getFutureBooking(id:number):Observable<Array<IBookingHistory>>
  {
    let params= new HttpParams()
    params=params.append('UserId',id)
    return this.http.get<Array<IBookingHistory>>(this.baseURL+"get-future",{params})
  }
}
