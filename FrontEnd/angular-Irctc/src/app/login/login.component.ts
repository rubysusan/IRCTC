import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginDetailsService } from '../login-details.service';
import { ILoginDetails } from '../ILoginDetails.Interface';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent implements OnInit {
  public loginGroup!:FormGroup;
  public login?:ILoginDetails;
   constructor(private fb:FormBuilder,private router:Router,private activatedRoute: ActivatedRoute,private logService:LoginDetailsService){

   }
   
  ngOnInit(){
    this.loginGroup=this.fb.group({
      userName:new FormControl(''),
      password:new FormControl('')
    })
  }
  onRegister(){
this.router.navigate(['./register']);
  }
  onLogin(){
    
      const logDetails=this.loginGroup?.value;
      this.login=this.logService.loginDetails.find(x=>x.userName===logDetails.userName)
      console.log(this.login?.userName)
      if(logDetails.userName===this.login?.userName)
      {
        if(logDetails.password===this.login?.password)
        {
          if(this.login?.userTypeId===1)
          {this.router.navigate(['./passenger']);}
          else{
            this.router.navigate(['./ttr']);
          }
        }
        else{
          alert("Wrong Password")
        }
        
      }
      else{
        alert("Wrong Username")
      }
  

}}
