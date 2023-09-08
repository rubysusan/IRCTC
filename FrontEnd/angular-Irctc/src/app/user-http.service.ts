import {
  HttpClient
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ILoginGet } from './ILoginGet.Interface';
import { ILoginDetails } from './ILoginDetails.Interface';

@Injectable({
  providedIn: 'root'
})
export class UserHttpService {
  private baseURL="https://localhost:7247/api/User/"
  constructor(private http:HttpClient) { }
  public getUser():Observable<Array<ILoginGet>>
  {
    return this.http.get<Array<ILoginGet>>(this.baseURL+"get");
  }
  public addUser(user:ILoginDetails):Observable<ILoginGet>
  {
    return this.http.post<ILoginGet>(this.baseURL+"add",user);
  }
}
