import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.sass']
})
export class RegisterComponent implements OnInit{

  public regGroup!:FormGroup;
  constructor(private fb:FormBuilder,private router:Router,private activatedRoute: ActivatedRoute){

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
 insert(){
  this.router.navigate(['.']);
 }
 onBack(){
  this.router.navigate(['.']);
 }

}
