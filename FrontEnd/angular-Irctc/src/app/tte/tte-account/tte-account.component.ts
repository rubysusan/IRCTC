import { Component } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { IUpdateData } from 'src/app/IUpdateData.Interface';
import { IViewUserDetails } from 'src/app/IViewUserDetails.Interface';
import { SearchDetailsService } from 'src/app/search-details.service';
import { UserHttpService } from 'src/app/user-http.service';

@Component({
  selector: 'app-tte-account',
  templateUrl: './tte-account.component.html',
  styleUrls: ['./tte-account.component.sass']
})
export class TteAccountComponent {
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
    this.val=false
  }
  val?:boolean
  edit:Array<IUpdateData>=[]
  editProfile()
  {
    this.val=true
  }
  onEdit()
  {
    //this.id,value.userName,value.email,value.password,value.identityCardID,this.selectedValue
    if (this.editGroup.valid) {
      const value = this.editGroup.value;
      const temp:IUpdateData={
        id:this.id,
        userName:value.userName,
        email:value.email,
        password:value.password,
        identityCardID:value.identityCardID,
        typeName:this.selectedValue
      }
      console.log(temp)
      this.userService.updateUserById(temp).subscribe((data:Array<IUpdateData>)=>{
         this.edit=data
          console.log(this.edit)})
          alert("Profile Edited Successfully")
          this.val=false
    }
  }

}
