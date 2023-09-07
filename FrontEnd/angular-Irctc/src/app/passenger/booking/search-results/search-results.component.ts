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
import { ISelectedTrain } from 'src/app/ISelectedTrain.Interface';
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
  selectedTrain:Array<ISelectedTrain>=[]  

  train:Array<ISearchedTrain>=[]
  trainDepartEF:Array<ISearchedTrain>=[]
  trainDepartLF:Array<ISearchedTrain>=[]
  trainArrivalEF:Array<ISearchedTrain>=[]
  trainArrivalLF:Array<ISearchedTrain>=[]



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
  id:number=0;
  tname:string="";
  fromStat:string="";
  toStat:string="";
  depart:string="";
  arriv:string="";
  coachVal:string="";
  tdate:string="";

  onCoach(trainId:number,trainName:string,fromStation:string,toStation:string,date:string,departure:string,arrival:string)
  {
    this.id=trainId;
    this.tname=trainName;
    this.fromStat=fromStation;
    this.toStat=toStation;
    this.tdate=date;
    this.depart=departure;
    this.arriv=arrival;
    

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
    this.coachVal=coach;
    this.chargeService.getCharge(this.id,this.from,this.to,coach)
    .subscribe((data:Array<IChargeValue>)=>{this.charge=data;
    console.log(this.charge)})

  }
  
  onDepartureEF(event:any){
    
    console.log(event.target.value); 
    if(event.target.value=="DepartureEF"){
    this.train==this.train.filter(x=>x.trainId).sort((a,b) => 0 - (a > b ? -1 : 1));
    this.trainDepartEF=this.train.filter(x=>x.departureTime).sort((a,b) => 0 - (a > b ? -1 : 1));
    this.train=this.trainDepartEF
    console.log(this.train);
    }

    else if (event.target.value=="DepartureLF"){
      this.train=this.train.filter(x=>x.trainId).sort((a,b) => 0 - (a > b ? -1 : 1));
      this.trainDepartLF=this.train.filter(x=>x.departureTime).sort((a,b) => 0 - (a > b ? 1 : -1));
      this.train=this.trainDepartLF
    console.log(this.train);
    }
    else if(event.target.value=="ArrivalEF"){
      this.train=this.train.filter(x=>x.trainId).sort((a,b) => 0 - (a > b ? -1 : 1));
      this.trainArrivalEF=this.train.filter(x=>x.reachingTime).sort((a,b) => 0 - (a > b ? -1 : 1));
      this.train=this.trainArrivalEF
    console.log(this.train);
    }
    else if(event.target.value=="ArrivalLF"){
      this.train=this.train.filter(x=>x.trainId).sort((a,b) => 0 - (a > b ? -1 : 1));
      this.trainArrivalLF=this.train.filter(x=>x.reachingTime).sort((a,b) => 0 - (a > b ? 1 : -1));
      this.train=this.trainArrivalLF
    console.log(this.train);
    }
  }
 onBook(){
  this.selectedTrain.push(<ISelectedTrain>({trainId:this.id,trainName:this.tname,
    fromStationName:this.fromStat,toStationName:this.toStat,coachName:this.coachVal,
    date:this.tdate,departureTime:this.depart,reachingTime:this.arriv}));

  this.searchService.setSelectedValue(this.selectedTrain);
  this.router.navigate(['./bookdetails'])
 
}




}
