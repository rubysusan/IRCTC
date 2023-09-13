import { Component, OnInit } from '@angular/core';
import { SearchDetailsService } from '../search-details.service';
import { PassengerDetailsService } from '../passenger-details.service';
import { ISelectedTrain } from '../ISelectedTrain.Interface';
import { IPassenger } from '../IPassenger.Interface';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';
import { BookingService } from '../booking.service';
import { IBooking } from '../IBooking.Interface';
import { IBookingData } from '../IBookingData.Interface';

@Component({
  selector: 'app-view-ticket',
  templateUrl: './view-ticket.component.html',
  styleUrls: ['./view-ticket.component.sass'],
})
export class ViewTicketComponent implements OnInit{
  public selectVal: Array<ISelectedTrain> = [];
  public newPassengerList: Array<IPassenger> = [];
  subs?: Subscription;
  bookId:number=0;
  total:number=0;
  constructor(private searchService: SearchDetailsService,
    private passengerService:PassengerDetailsService,
    private router: Router,
    private bookingService: BookingService) {}

  ngOnInit(){
    this.subs = this.searchService.select.subscribe(
      (x: Array<ISelectedTrain>) => (this.selectVal = x)
    );
    console.log(this.selectVal);
    this.subs=this.passengerService.passenger.subscribe(
      (x:Array<IPassenger>)=>{
        (this.newPassengerList=x)
      this.bookId=this.newPassengerList[0].bookId
    }
    )
    this.subs = this.bookingService.bookingData.subscribe(
      (x: IBookingData) =>{ this.total=x.totalCost
        console.log(this.total)
  });
    
      
  }
  onDone(){
    this.router.navigate(['passenger']);
  }
}
  


