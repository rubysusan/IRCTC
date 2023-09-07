import { Component, Input, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ISearchedTrain } from 'src/app/ISearchedTrain.Interface';
import { SearchDetailsService } from 'src/app/search-details.service';
import { TrainsSearchHttpService } from 'src/app/trains-search-http.service';
import { BookingComponent } from '../booking.component';
import { IValuesSearched } from 'src/app/IValuesSearched.Interface';
import { Subscription } from 'rxjs';
import { SeatHttpService } from 'src/app/seat-http.service';
import { ISeatDetails } from 'src/app/ISeatDetails.Interface';
import { TraintypeHttpService } from 'src/app/traintype-http.service';
import { ChargeHttpService } from 'src/app/charge-http.service';
interface IChargeValue{
  charge:number;
}
@Component({
  selector: 'app-search-results',
  templateUrl: './search-results.component.html',
  styleUrls: ['./search-results.component.sass']
})
export class SearchResultsComponent implements OnInit {
  seat:Array<ISeatDetails>=[]
  searchVal:Array<IValuesSearched>=[]
  subs?:Subscription 
  searchDate:string='';
  from:string=''
  to:string=''
  dateVal:string=''
  coach:string=''
  id:number=0;

  train:Array<ISearchedTrain>=[]
  constructor(private seatService:SeatHttpService,private trainService:TrainsSearchHttpService,private searchService:SearchDetailsService,private router: Router,
    private activatedRoute: ActivatedRoute,private booking:BookingComponent,private chargeService:ChargeHttpService,private trainTypeService:TraintypeHttpService) {
      this.subs=this.searchService.search.subscribe((x:Array<IValuesSearched>) => this.searchVal=x)
    console.log(this.searchVal)
    this.from=String(this.searchVal.map(x=>x.fromVal))
    this.to=String(this.searchVal.map(x=>x.toVal))
    this.dateVal=String(this.searchVal.map(x=>x.dateVal))
    this.coach=String(this.searchVal.map(x=>x.coachVal))
    
  }
  ngOnInit():void
  {
    this.trainService.getTrainBySearch(this.from,
     this.to,this.dateVal+'T00:00:00',this.coach)
      .subscribe((data:Array<ISearchedTrain>)=>{this.train=data;
      console.log(this.train)})  
      
  }
  onCoach(trainId:number)
  {
    this.id=trainId;
    this.seatService.getSeats(trainId).subscribe((data:Array<ISeatDetails>)=>{this.seat=data;
      console.log(this.seat)})
  }
  dateSearched:Date=new Date()
  onFilterDate(event:any)
  {
    this.dateVal=event.target.value;
    console.log(this.dateSearched)
    this.trainService.getTrainBySearch(this.from,
      this.to,this.dateVal+'T00:00:00',this.coach)
       .subscribe((data:Array<ISearchedTrain>)=>{this.train=data;
       console.log(this.train)}) 
  }
  trainTypeSearched:string=''
  getSelectedTrainType(event:any)
  {
    this.trainTypeSearched=event.target.value;
    console.log(this.trainTypeSearched)
    this.trainTypeService.getTrainByType(this.from,
      this.to,this.dateVal,this.coach,this.trainTypeSearched)
       .subscribe((data:Array<ISearchedTrain>)=>{this.train=data;
       console.log(this.train)})  
  }
  classSearched:string=''
  getSelectedClass(event:any)
  {
    this.coach=event.target.value
    console.log(this.classSearched)
    this.trainService.getTrainBySearch(this.from,
      this.to,this.dateVal,this.coach)
       .subscribe((data:Array<ISearchedTrain>)=>{this.train=data;
       console.log(this.train)}) 
  }
  charge:Array<IChargeValue>=[];
  onSeat(coach:string)
  {
    this.chargeService.getCharge(this.id,this.from,this.to,coach)
    .subscribe((data:Array<IChargeValue>)=>{this.charge=data;
    console.log(this.charge)})

  }

}
