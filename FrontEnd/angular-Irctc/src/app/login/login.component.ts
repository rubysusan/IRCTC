import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginDetailsService } from '../login-details.service';
import { ILoginDetails } from '../ILoginDetails.Interface';
import { UserHttpService } from '../user-http.service';
import { ILoginGet } from '../ILoginGet.Interface';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent implements OnInit {
  public loginGroup!:FormGroup;
  public login?:ILoginDetails;
  public user:Array<ILoginGet>=[]
   constructor(private userService:UserHttpService,private fb:FormBuilder,private router:Router,private activatedRoute: ActivatedRoute,private logService:LoginDetailsService){
    this.userService.getUser().subscribe((data:Array<ILoginGet>)=>{this.user=data;
    console.log(this.user)})
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
      this.login=this.user.find(x=>x.userName===logDetails.userName)
      console.log(this.login?.userName)
      if(logDetails.userName===this.login?.userName)
      {
        if(logDetails.password===this.login?.password)
        {
          this.router.navigate(['./passenger']);
          // if(this.login?.userTypeId===1)
          // {this.router.navigate(['./passenger']);}
          // else{
          //   this.router.navigate(['./ttr']);
          // }
        }
        else{
          alert("Wrong Password")
        }
        
      }
      else{
        alert("Wrong Username")
      }
  

}}
