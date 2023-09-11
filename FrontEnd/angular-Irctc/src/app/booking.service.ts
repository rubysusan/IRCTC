import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IBooking } from './IBooking.Interface';
import { IBookingData } from './IBookingData.Interface';

@Injectable({
  providedIn: 'root'
})
export class BookingService {

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
}
