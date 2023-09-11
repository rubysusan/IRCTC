import {
  HttpClient, HttpParams
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ILoginGet } from './ILoginGet.Interface';
import { ILoginDetails } from './ILoginDetails.Interface';
import { IUserDetails } from './IUserDetails.Interface';
import { IViewUserDetails } from './IViewUserDetails.Interface';

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
  public updateUserById(id:number,name:string,mail:string,pass:string,card:string,type:string)
  :Observable<Array<ILoginGet>>
  {
    let params=new HttpParams()
    params=params.append('Id',id)
    params=params.append('UserName',name)
    params=params.append('Email',mail)
    params=params.append('Password',pass)
    params=params.append('IdCard',card)
    params=params.append('TypeName',type)
    return this.http.put<Array<ILoginGet>>(this.baseURL+'update',{params});
  }
}
