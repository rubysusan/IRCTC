import { Component, OnInit } from '@angular/core';
import { PassengerHttpService } from '../passenger-http.service';
import { Subscription } from 'rxjs';
import { IPassengerTTE } from '../IPassengerTTE.Interface';

@Component({
  selector: 'app-tte-passenger-view',
  templateUrl: './tte-passenger-view.component.html',
  styleUrls: ['./tte-passenger-view.component.sass']
})
export class TtePassengerViewComponent implements OnInit{
  constructor(private passengerHttpService:PassengerHttpService){}
  trainId:number=0;
  subs?:Subscription;
  passengerData:Array<IPassengerTTE>=[];
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
}
