import { Component, OnInit } from '@angular/core';
import { SearchDetailsService } from '../search-details.service';
import { Subscription } from 'rxjs';
import { ISelectedTrain } from '../ISelectedTrain.Interface';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { IPassenger } from '../IPassenger.Interface';
import { PassengerDetailsService } from '../passenger-details.service';
import { BookingService } from '../booking.service';
import { IBookingData } from '../IBookingData.Interface';
import { ChargeHttpService } from '../charge-http.service';
import { SeatHttpService } from '../seat-http.service';
import { ISeatForPassenger } from '../ISeatForPassenger.Interface';
import { TrainClassService } from '../train-class.service';
enum seatTypeEnum{
  LowerBerth=1,
  UpperBerth,
  MiddleBerth,
  WindowSeat,
  MiddleSeat,
  AisleSeat
}
interface IChargeValue {
  charge: number;
}
interface ITrainClass{
  trainClassId:number;
}


@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.sass'],
})
export class BookDetailsComponent implements OnInit {
  public passengerGroup!: FormGroup;
  subs?: Subscription;
  subscript?: Subscription;
  sub?: Subscription;
  selectVal: Array<ISelectedTrain> = [];
  view?: Boolean;
  selectedValue: any;
  seatValue:any;
  seatValueId:number=0;
  typeValue: number = 0;
  passengerCount:number=0;
  cost: Array<IChargeValue> = [];
  uId:number=0;
  public newPassenger: Array<IPassenger> = [];
  public newPassengerList:Array<IPassenger>=[];
  public newBooking?:IBookingData;
  
  constructor(
    private searchService: SearchDetailsService,
    private fb: FormBuilder,
    private passengerService:  PassengerDetailsService,
    private bookingService:BookingService,
    private chargeService:ChargeHttpService,
    private seatService:SeatHttpService,
    private trainClassService:TrainClassService
  ) {}

  ngOnInit(): void {
    this.passengerGroup = this.fb.group({
      passengerName: new FormControl('',[Validators.required]),
      passengerAge: new FormControl('',[Validators.required]),
      passengeGender: new FormControl('',[Validators.required]),
      preference: new FormControl('',[Validators.required]),
      seatName:new FormControl('')

    });

    this.subs = this.searchService.select.subscribe(
      (x: Array<ISelectedTrain>) => (this.selectVal = x)
    );
    console.log(this.selectVal);
   

    this.subscript = this.chargeService.charge.subscribe(
      (x:Array<IChargeValue>) => {this.cost = x;
        console.log(this.cost)
      }
    );
    console.log(this.cost);
    this.sub=this.searchService.idVal.subscribe(
      (x:number)=>(this.uId=x)
    );
    console.log(this.uId);

  }
  trainClass:Array<ITrainClass>=[];
  trainClassId:number=0;
  coachId:number=0;
  trainId:number=0;
  seats:Array<ISeatForPassenger>=[]
  getSelectedValue(event: any) {
    this.selectedValue = event.target.value;
    if (this.selectedValue === seatTypeEnum[seatTypeEnum.LowerBerth]) 
    {
      this.typeValue = seatTypeEnum.LowerBerth;
    } 
    else if(this.selectedValue===seatTypeEnum[seatTypeEnum.UpperBerth])
    {
      this.typeValue = seatTypeEnum.UpperBerth;
    }
    else if(this.selectedValue===seatTypeEnum[seatTypeEnum.MiddleBerth])
    {
      this.typeValue = seatTypeEnum.MiddleBerth;
    }
    else if(this.selectedValue===seatTypeEnum[seatTypeEnum.WindowSeat])
    {
      this.typeValue = seatTypeEnum.WindowSeat;
    }
    else if(this.selectedValue===seatTypeEnum[seatTypeEnum.MiddleSeat])
    {
      this.typeValue = seatTypeEnum.MiddleSeat;
    }
    else if(this.selectedValue===seatTypeEnum[seatTypeEnum.AisleSeat])
    {
      this.typeValue = seatTypeEnum.AisleSeat;
    }
    this.coachId=Number(this.selectVal.map(x=>x.coachId))
    this.trainId=Number(this.selectVal.map(x=>x.trainId))
    console.log(this.selectVal);
    console.log(this.coachId);
    console.log(this.typeValue);
    console.log(this.trainId);
    this.trainClassService.getTrainClassId(this.trainId,this.coachId).subscribe(
      (data:Array<ITrainClass>)=>{this.trainClass=data;
      console.log(this.trainClass)});
    setTimeout(()=>{console.log(this.trainClass);
    this.trainClassId=Number(this.trainClass.map(x=>x.trainClassId));
    console.log(this.trainClassId);
    this.seatService.getSeatForPassenger(this.typeValue,this.trainClassId).subscribe(
      (data:Array<ISeatForPassenger>)=>{this.seats=data});
      console.log(this.seats);},500);
    console.log(this.typeValue);
    console.log(event.target.value);
  }
  addPassenger() {
    this.view = true;
  }
  add() {
    this.view = false;
    if (this.passengerGroup.valid) {
      const val = this.passengerGroup.value;
      console.log(val);
      const temp: IPassenger = {
       bookId:-1,
       name:val.passengerName,
       age:val.passengerAge,
       gender:val.passengeGender,
       preference:this.typeValue,
       seatName:this.seatValue,
       seatId:this.seatValueId
      };
      console.log(temp);
      this.newPassenger.push(<IPassenger>{
        bookId:temp.bookId,
        name:temp.name,
        age:temp.age,
        gender:temp.gender,
        preference:temp.preference,
        seatName:temp.seatName,
        seatId:temp.seatId
      })
      console.log(this.newPassenger)
      this.passengerService.setValue(this.newPassenger)
      this.newPassengerList=this.newPassenger.filter(x=>x.bookId===-1);
      console.log(this.newPassengerList);
      this.passengerCount=this.newPassengerList.length;
    }
  }
  costVal:number =0
  onBook(){
    this.costVal=Number(this.cost.map(x=>x.charge))
    this.newBooking={
      trainClassId:this.trainClassId,
      fromStop:Number(this.selectVal.map(x=>x.fromStationId)),
      toStop:Number(this.selectVal.map(x=>x.toStationId)),
      count:this.passengerCount,
      totalCost:(this.costVal)*this.passengerCount,
      userId:this.uId
    }
    console.log(Number(this.selectVal.map(x=>x.fromStationId)));
    console.log(Number(this.selectVal.map(x=>x.toStationId)));
    console.log(this.passengerCount);
    console.log(this.cost);
   
    
    console.log(this.costVal);
    console.log((this.costVal)*this.passengerCount);
    this.bookingService.addBookingDetails(this.newBooking).subscribe((data) => {
      console.log(data);

    
  })
  }
  getSelectedSeatValue(event: any){
    this.seatValue=event.target.value;
    console.log(this.seatValue);
    this.seatValueId=Number(this.seats.filter(x=>x.seatName===this.seatValue).map(x=>x.seatId));
    console.log(this.seatValueId);
    console.log(this.seats.map(x=>x.seatId));
  }
}
