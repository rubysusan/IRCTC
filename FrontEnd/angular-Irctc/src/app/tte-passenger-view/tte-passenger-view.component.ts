import { Component, OnInit } from '@angular/core';
import { PassengerHttpService } from '../passenger-http.service';
import { Subscription } from 'rxjs';
import { IPassengerTTE } from '../IPassengerTTE.Interface';
import { PassengerDetailsService } from '../passenger-details.service';
import { IPassengerStatus } from '../IPassengerStatus.Interface';
import { Router } from '@angular/router';

interface IPassengerId{
  id:number
}
@Component({
  selector: 'app-tte-passenger-view',
  templateUrl: './tte-passenger-view.component.html',
  styleUrls: ['./tte-passenger-view.component.sass']
})
export class TtePassengerViewComponent implements OnInit{
  view:boolean=true;
  constructor(private router:Router ,private passengerHttpService:PassengerHttpService,private passengerDetailsService:PassengerDetailsService){}
  trainId:number=0;
  subs?:Subscription;
  sub?:Subscription;
  passengerData:Array<IPassengerTTE>=[];
  statusVal:Array<IPassengerStatus>=[]

  ngOnInit(){
   this.subs = this.passengerHttpService.trainId.subscribe(
    (x:number) => {
      this.trainId = x;
      console.log(this.trainId);
      this.passengerHttpService.getPassenger(this.trainId).subscribe((data: Array<IPassengerTTE>) => {
        this.passengerData = data;
        console.log(this.passengerData);
    })
  })
  }
  idVal:IPassengerId={
    id:0
  }
stat:string=''
val:Array<IPassengerStatus>=[]
onCheck(event:any,passId:number)
{
  this.idVal={
    id:passId
  }
  if(event.currentTarget.checked)
  {
    this.passengerHttpService.updatePassenger(this.idVal).subscribe((data:boolean)=>console.log(data))
    
    this.view=false
    this.setVal()
  }
}
setVal()
{
  this.view=true
}
onHome()
{
  this.router.navigate(['tte'])
}
}
