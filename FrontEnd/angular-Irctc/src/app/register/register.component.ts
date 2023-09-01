import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ILoginDetails } from '../ILoginDetails.Interface';
import { UserHttpService } from '../user-http.service';

enum userTypeEnum{
  Passenger=1,
  TTE
}

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.sass']
})
export class RegisterComponent implements OnInit{
  selectedValue:any;
  typeValue:number=0;
public newUser:ILoginDetails={
  userName:"",
  password:"",
  email:"",
  identityCardID:"",
  userTypeId:0
}
  public regGroup!:FormGroup;
  constructor(private userService:UserHttpService,private fb:FormBuilder,
    private router:Router,private activatedRoute: ActivatedRoute){

  }
 ngOnInit(){
   this.regGroup=this.fb.group({
     userName:new FormControl(''),
     password:new FormControl(''),
     email:new FormControl(''),
     idCard:new FormControl(''),
     userType:new FormControl('')
   })
 }
 getSelectedValue(event:any){
  
  this.selectedValue=event.target.value;
  if(this.selectedValue===userTypeEnum[userTypeEnum.Passenger])
  {
    this.typeValue=1;
    
  }
  else{
    this.typeValue=2;
  }
  console.log(this.typeValue)
  console.log(event.target.value);
}
 insert(){
  const val=this.regGroup.value;
  const temp:ILoginDetails={
    userName:val.userName||'',
    password:val.password||'',
    email:val.email||'',
    identityCardID:val.identityCardID||'',
    userTypeId:1
  }
  this.newUser.userName=temp.userName;
  this.newUser.password=temp.password;
  this.newUser.email=temp.email;
  this.newUser.identityCardID=temp.identityCardID;
  this.newUser.userTypeId=this.typeValue;
  this.userService.addUser(this.newUser).subscribe(data=>{console.log(data)})
  alert("Successfully Registered");
  this.router.navigate(['.']);
 }
 onBack(){
  this.router.navigate(['.']);
 }

}
