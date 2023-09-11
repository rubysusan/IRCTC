import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginDetailsService } from '../login-details.service';
import { ILoginDetails } from '../ILoginDetails.Interface';
import { UserHttpService } from '../user-http.service';
import { ILoginGet } from '../ILoginGet.Interface';
import { IUserDetails } from '../IUserDetails.Interface';
import { SearchDetailsService } from '../search-details.service';
import { Subscription } from 'rxjs';
enum userTypeEnum {
  Passenger = 1,
  TTE,
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass'],
})
export class LoginComponent implements OnInit {
  public loginGroup!: FormGroup;
  public login?: IUserDetails;
  public user: Array<IUserDetails> = [];
  constructor(
    private userService: UserHttpService,
    private fb: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private logService: LoginDetailsService,private searchService: SearchDetailsService
  ) {}
  id:number=0;
  type:number=0;
  ngOnInit() {
    this.loginGroup = this.fb.group({
      userName: new FormControl(''),
      password: new FormControl(''),
    });
   
  }
  onRegister() {
    this.router.navigate(['register']);
  }
  
  onLogin() {
    const logDetails = this.loginGroup?.value;
    this.userService.getUserOnLogin(logDetails.userName,logDetails.password).subscribe((data: Array<IUserDetails>) => {
      this.user = data;
      console.log(this.user);
      this.id=Number(this.user.map(x=>x.userId))
      this.type=Number(this.user.map(x=>x.userTypeId))
      this.searchService.setUser(this.id,this.type)
      if(this.id==0)
      {
        alert("Wrong Credentials")
      }
      else if(this.type==userTypeEnum.Passenger)
      {
        this.router.navigate(['passenger'])
      }
      else{
        this.router.navigate(['tte'])
      }
    }); 
    
    
  }
}
