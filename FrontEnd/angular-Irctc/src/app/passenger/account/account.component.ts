import { Component, OnInit } from '@angular/core';
import { FormBuilder,FormControl,
  FormGroup,
  Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { IBookingHistory } from 'src/app/IBookingHistory.Interface';
import { ILoginDetails } from 'src/app/ILoginDetails.Interface';
import { ILoginGet } from 'src/app/ILoginGet.Interface';
import { IUpdateData } from 'src/app/IUpdateData.Interface';
import { IViewUserDetails } from 'src/app/IViewUserDetails.Interface';
import { BookingService } from 'src/app/booking.service';
import { CancelHttpService } from 'src/app/cancel-http.service';
import { SearchDetailsService } from 'src/app/search-details.service';
import { UserHttpService } from 'src/app/user-http.service';
interface IBook{
  bookingId:number;
}
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
   private searchService: SearchDetailsService,private bookService:BookingService,
   private cancelService:CancelHttpService)
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
  past?:boolean
  future?:boolean
  onDone()
  {
    this.view=false
    this.past=false
    this.future=false
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
  bookPast:Array<IBookingHistory>=[]
  
  bookFuture:Array<IBookingHistory>=[]
  
  pastBookings()
  {
    this.past=true;
    this.bookService.getPastBooking(this.id).subscribe((data:Array<IBookingHistory>)=>{
      this.bookPast=data
      console.log(this.bookPast)
    })
  }
  futureBookings()
  {
    this.future=true
    this.bookService.getFutureBooking(this.id).subscribe((data:Array<IBookingHistory>)=>{
      this.bookFuture=data
      console.log(this.bookFuture)
    })
  }
  book:IBook={
    bookingId:0
  }
  onCancel(id:number){
    this.book={
      bookingId:id
    }
    this.cancelService.cancel(this.book).subscribe((data)=>{
      console.log(data);this.futureBookings();
      })
    alert("Cancelled Successfully")
  }
  onHome(){
    this.router.navigate(['passenger'])
  }
}
