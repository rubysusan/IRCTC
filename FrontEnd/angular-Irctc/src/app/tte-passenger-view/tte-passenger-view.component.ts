import { Component, OnInit } from '@angular/core';
import { PassengerHttpService } from '../passenger-http.service';
import { Subscription } from 'rxjs';
import { IPassengerTTE } from '../IPassengerTTE.Interface';
import { PassengerDetailsService } from '../passenger-details.service';
import { IPassengerStatus } from '../IPassengerStatus.Interface';

@Component({
  selector: 'app-tte-passenger-view',
  templateUrl: './tte-passenger-view.component.html',
  styleUrls: ['./tte-passenger-view.component.sass']
})
export class TtePassengerViewComponent implements OnInit{
  view:boolean=true;
  constructor(private passengerHttpService:PassengerHttpService,private passengerDetailsService:PassengerDetailsService){}
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
  this.sub=this.passengerDetailsService.status.subscribe((x:Array<IPassengerStatus>)=>{this.statusVal=x})
}
stat:string=''
val:Array<IPassengerStatus>=[]
onCheck(event:any,id:number)
{
  if(event.currentTarget.checked)
  {
    this.val=[{
passengerId:id,
status:'Arrived'
    }]
    this.stat='Arrived'
    this.passengerDetailsService.setStatusValue(this.val)
    this.view=false
  }
}
onStatusCheck()
{
  if(this.statusVal.find(x=>x.status=='Arrived'))
  {
    return false
  }
  else
  {
    return true
  }
}
}
