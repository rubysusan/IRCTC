import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
interface IBook{
  bookingId:number;
}
@Injectable({
  providedIn: 'root'
})
export class CancelHttpService {
  private baseURL="https://localhost:7247/api/Cancellation/"
  constructor(private http:HttpClient) { }
public cancel(id:IBook):Observable<IBook>
{
  
  return this.http.put<IBook>(this.baseURL+"cancel",id)
}
}
