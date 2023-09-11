import { Component, OnInit } from '@angular/core';
import { FormBuilder,FormControl,
  FormGroup,
  Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { ILoginDetails } from 'src/app/ILoginDetails.Interface';
import { ILoginGet } from 'src/app/ILoginGet.Interface';
import { IViewUserDetails } from 'src/app/IViewUserDetails.Interface';
import { SearchDetailsService } from 'src/app/search-details.service';
import { UserHttpService } from 'src/app/user-http.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.sass']
})
export class AccountComponent implements OnInit {
  id:number=0;
  subs?:Subscription
  user:Array<IViewUserDetails>=[]
  public editGroup!:FormGroup
  constructor(private userService: UserHttpService,private router: Router,private fb:FormBuilder,
    private activatedRoute: ActivatedRoute,
   private searchService: SearchDetailsService)
  {}
  ngOnInit(): void {
    this.subs=this.searchService.idVal.subscribe((x:number)=>(this.id=x));
   
    this.editGroup = this.fb.group({
      userName: new FormControl(),
      password: new FormControl(''),
      email: new FormControl(''),
      identityCardID: new FormControl(''),
      userType: new FormControl(''),
    });
  }
  selectedValue:string=''
  getSelectedValue(event: any) {
    this.selectedValue = event.target.value;}
  view?:boolean
  viewProfile()
  {
    this.view=true
    this.userService.getUserById(this.id).subscribe((data: Array<IViewUserDetails>) => {
      this.user = data;
    console.log(this.user)});
 
  }
  onDone()
  {
    this.view=false
  }
  val?:boolean
  edit:Array<ILoginGet>=[]
  editProfile()
  {
    this.val=true
  }
  onEdit()
  {
    //this.id,value.userName,value.email,value.password,value.identityCardID,this.selectedValue
    if (this.editGroup.valid) {
      const value = this.editGroup.value;
      console.log(value.userName)
      console.log(this.selectedValue)
      this.userService.updateUserById(this.id,value.userName,value.email,value.password,value.identityCardID,this.selectedValue).subscribe((data:Array<ILoginGet>)=>{
         this.edit=data
          console.log(data)})
    }
  }
  pastBookings()
  {

  }
  futureBookings()
  {

  }

}
