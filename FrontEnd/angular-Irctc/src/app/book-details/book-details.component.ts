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
    private chargeService:ChargeHttpService
  ) {}

  ngOnInit(): void {
    this.passengerGroup = this.fb.group({
      passengerName: new FormControl('',[Validators.required]),
      passengerAge: new FormControl('',[Validators.required]),
      passengeGender: new FormControl('',[Validators.required]),
      preference: new FormControl('',[Validators.required]),
    });

    this.subs = this.searchService.select.subscribe(
      (x: Array<ISelectedTrain>) => (this.selectVal = x)
    );
    console.log(this.selectVal);

    this.subscript = this.chargeService.charge.subscribe(
      (x: Array<IChargeValue>) => (this.cost = x)
    );
    console.log(this.cost);
    this.sub=this.searchService.idVal.subscribe(
      (x:number)=>(this.uId=x)
    );
    console.log(this.uId);

  }
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
       preference:this.typeValue
      };
      console.log(temp);
      this.newPassenger.push(<IPassenger>{
        bookId:temp.bookId,
        name:temp.name,
        age:temp.age,
        gender:temp.gender,
        preference:temp.preference
      })
      console.log(this.newPassenger)
      this.passengerService.setValue(this.newPassenger)
      this.newPassengerList=this.newPassenger.filter(x=>x.bookId===-1);
      console.log(this.newPassengerList);
      this.passengerCount=this.newPassengerList.length;
    }
  }
  onBook(){
    this.newBooking={
      trainClassId:Number(this.selectVal.map(x=>x.coachId)),
      fromStop:Number(this.selectVal.map(x=>x.fromStationId)),
      toStop:Number(this.selectVal.map(x=>x.toStationId)),
      count:this.passengerCount,
      totalCost:(Number(this.cost))*this.passengerCount,
      userId:this.uId
    }
    console.log(Number(this.selectVal.map(x=>x.fromStationId)));
    console.log(Number(this.selectVal.map(x=>x.toStationId)));
    console.log(this.passengerCount)
    this.bookingService.addBookingDetails(this.newBooking).subscribe((data) => {
      console.log(data);
  })
  }
}
