import { Injectable } from '@angular/core';
import { ILoginDetails } from './ILoginDetails.Interface';

@Injectable({
  providedIn: 'root'
})
export class LoginDetailsService {
public loginDetails:Array<ILoginDetails>=[
  {
    userName:"Asna",
    password:"123",
    email:"asna@gmail.com",
    identityCardID:"A123",
    userTypeId:1,
  },{
    userName:"Ruby",
    password:"123",
    email:"ruby@gmail.com",
    identityCardID:"A123",
    userTypeId:1,
  }
]

}
