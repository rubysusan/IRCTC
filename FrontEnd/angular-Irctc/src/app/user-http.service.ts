import {
  HttpClient, HttpParams
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ILoginGet } from './ILoginGet.Interface';
import { ILoginDetails } from './ILoginDetails.Interface';
import { IUserDetails } from './IUserDetails.Interface';
import { IViewUserDetails } from './IViewUserDetails.Interface';
import { IUpdateData } from './IUpdateData.Interface';

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
  public getUserOnLogin(name:string,pass:string):Observable<Array<IUserDetails>>
  {
    let params=new HttpParams()
    params=params.append('UserName',name)
    params=params.append('Password',pass)
    return this.http.get<Array<IUserDetails>>(this.baseURL+'get-on-login',{params});
  }
  public getUserById(id:number):Observable<Array<IViewUserDetails>>
  {
    let params=new HttpParams()
    params=params.append('UserId',id)
    return this.http.get<Array<IViewUserDetails>>(this.baseURL+'get-by-id',{params});
  }
  public updateUserById(user:IUpdateData)
  :Observable<Array<IUpdateData>>
  {
  
    return this.http.put<Array<IUpdateData>>(this.baseURL+'update',user);
  }
}
