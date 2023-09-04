import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ILoginGet } from 'src/app/ILoginGet.Interface';
import { UserHttpService } from 'src/app/user-http.service';


@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.sass']
})
export class BookingComponent implements OnInit{
user:Array<ILoginGet>=[]
constructor(private userService:UserHttpService,private router:Router,
  private activatedRoute: ActivatedRoute, private formBuilder: FormBuilder) {
    this.userService.getUser().subscribe((data:Array<ILoginGet>)=>{this.user=data;
      console.log(this.user)})
}
val:string=''
data:Array<ILoginGet>=[]
fromSearch=new FormGroup({from:new FormControl('')});

ngOnInit(): void {
  this.fromSearch.controls['from'].valueChanges.subscribe(value=>{
    console.log(value);
    this.val=value!;
    this.data=this.user.filter(x=>x.userName.toLocaleLowerCase().includes(this.val.toLocaleLowerCase()));
    console.log(this.data);
  }); 
  
  
}
onFromSearch()
{

}
}
