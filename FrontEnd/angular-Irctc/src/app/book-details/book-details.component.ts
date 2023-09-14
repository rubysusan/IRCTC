import { Component, OnInit } from '@angular/core';
import { SearchDetailsService } from '../search-details.service';
import { Subscription } from 'rxjs';
import { ISelectedTrain } from '../ISelectedTrain.Interface';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { IPassenger } from '../IPassenger.Interface';
import { PassengerDetailsService } from '../passenger-details.service';
import { BookingService } from '../booking.service';
import { IBookingData } from '../IBookingData.Interface';
import { ChargeHttpService } from '../charge-http.service';
import { AvailableSeatHttpService } from '../available-seat-http.service';
import { ISeatForPassenger } from '../ISeatForPassenger.Interface';
import { TrainClassService } from '../train-class.service';
import { SeatService } from '../seat.service';
import { IUpdateSeat } from '../IUpdateSeat.Interface';
import { IBooking } from '../IBooking.Interface';
import { Router } from '@angular/router';
import { IPassengerInsert } from '../IPassengerInsert.Interface';
import { PassengerHttpService } from '../passenger-http.service';
enum seatTypeEnum {
  LowerBerth = 1,
  UpperBerth,
  MiddleBerth,
  WindowSeat,
  MiddleSeat,
  AisleSeat,
}
enum bookingStatusEnum {
  Confirmed=1,
  Cancelled
}
interface IChargeValue {
  charge: number;
}
interface ITrainClass {
  trainClassId: number;
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
  seatValue: any;
  seatValueId: number = 0;
  typeValue: number = 0;
  passengerCount: number = 0;
  cost: Array<IChargeValue> = [];
  uId: number = 0;
  total:number=0;
  public newPassenger: Array<IPassenger> = [];
  public newPassengerList: Array<IPassenger> = [];
  public newBooking: IBookingData={ trainClassId:0,
    fromStop:0,
    toStop:0,
    count:0,
    totalCost:0,
    userId:0,
    bookingStatusId:0};

  constructor(
    private searchService: SearchDetailsService,
    private fb: FormBuilder,
    private passengerService: PassengerDetailsService,
    private bookingService: BookingService,
    private chargeService: ChargeHttpService,
    private availableSeatService: AvailableSeatHttpService,
    private seatService: SeatService,
    private trainClassService: TrainClassService,
    private router: Router,
    private passengerHttpService:PassengerHttpService
  ) {}

  ngOnInit(): void {
    this.passengerGroup = this.fb.group({
      passengerName: new FormControl('', [Validators.required]),
      passengerAge: new FormControl('', [Validators.required]),
      passengeGender: new FormControl('', [Validators.required]),
      preference: new FormControl('', [Validators.required]),
      seatName: new FormControl(''),
    });

    this.subs = this.searchService.select.subscribe(
      (x: Array<ISelectedTrain>) => (this.selectVal = x)
    );
    console.log(this.selectVal);

    this.subscript = this.chargeService.charge.subscribe(
      (x: Array<IChargeValue>) => {
        this.cost = x;
        console.log(this.cost);
      }
    );
    console.log(this.cost);
    this.sub = this.searchService.idVal.subscribe(
      (x: number) => (this.uId = x)
    );
    console.log(this.uId);
  }
  trainClass: Array<ITrainClass> = [];
  trainClassId: number = 0;
  coachId: number = 0;
  trainId: number = 0;
  seats: Array<ISeatForPassenger> = [];
  seat: IUpdateSeat = { seatId: 0 };
  newBookId:number=0;
  indexes:Array<number>=[]
  getSelectedValue(event: any) {
    this.selectedValue = event.target.value;
    if (this.selectedValue === seatTypeEnum[seatTypeEnum.LowerBerth]) {
      this.typeValue = seatTypeEnum.LowerBerth;
    } else if (this.selectedValue === seatTypeEnum[seatTypeEnum.UpperBerth]) {
      this.typeValue = seatTypeEnum.UpperBerth;
    } else if (this.selectedValue === seatTypeEnum[seatTypeEnum.MiddleBerth]) {
      this.typeValue = seatTypeEnum.MiddleBerth;
    } else if (this.selectedValue === seatTypeEnum[seatTypeEnum.WindowSeat]) {
      this.typeValue = seatTypeEnum.WindowSeat;
    } else if (this.selectedValue === seatTypeEnum[seatTypeEnum.MiddleSeat]) {
      this.typeValue = seatTypeEnum.MiddleSeat;
    } else if (this.selectedValue === seatTypeEnum[seatTypeEnum.AisleSeat]) {
      this.typeValue = seatTypeEnum.AisleSeat;
    }
    this.coachId = Number(this.selectVal.map((x) => x.coachId));
    this.trainId = Number(this.selectVal.map((x) => x.trainId));
    console.log(this.selectVal);
    console.log(this.coachId);
    console.log(this.typeValue);
    console.log(this.trainId);
    this.trainClassService
      .getTrainClassId(this.trainId, this.coachId)
      .subscribe((data: Array<ITrainClass>) => {
        this.trainClass = data;
        console.log(this.trainClass);
      });
    setTimeout(() => {
      console.log(this.trainClass);
      this.trainClassId = Number(this.trainClass.map((x) => x.trainClassId));
      console.log(this.trainClassId);
      this.availableSeatService
        .getSeatForPassenger(this.typeValue, this.trainClassId)
        .subscribe((data: Array<ISeatForPassenger>) => {
          this.seats = data;
        });
      console.log(this.seats);
    }, 500);
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
        bookId: -1,
        name: val.passengerName,
        age: val.passengerAge,
        gender: val.passengeGender,
        preference: this.typeValue,
        seatName: this.seatValue,
        seatId: this.seatValueId,
      };
      console.log(temp);
      this.newPassenger.push(<IPassenger>{
        bookId: temp.bookId,
        name: temp.name,
        age: temp.age,
        gender: temp.gender,
        preference: temp.preference,
        seatName: temp.seatName,
        seatId: temp.seatId,
      });
      console.log(this.newPassenger);
      
      this.newPassengerList = this.newPassenger.filter((x) => x.bookId === -1);
      console.log(this.newPassengerList);
      this.passengerCount = this.newPassengerList.length;
    }
    this.costVal = Number(this.cost.map((x) => x.charge));
    this.total=this.costVal * this.passengerCount
  }
  costVal: number = 0;
  passenger:IPassengerInsert={
    passengerName:'',
    seatId:0,
    bookingId:0
  }
  onBook() {
    
    this.newBooking = {
      trainClassId: this.trainClassId,
      fromStop: Number(this.selectVal.map((x) => x.fromStationId)),
      toStop: Number(this.selectVal.map((x) => x.toStationId)),
      count: this.passengerCount,
      totalCost: this.costVal * this.passengerCount,
      userId: this.uId,
      bookingStatusId:bookingStatusEnum.Confirmed
    };
    console.log(Number(this.selectVal.map((x) => x.fromStationId)));
    console.log(Number(this.selectVal.map((x) => x.toStationId)));
    console.log(this.passengerCount);
    console.log(this.cost);

    console.log(this.costVal);
    console.log(this.costVal * this.passengerCount);
    this.bookingService.addBookingDetails(this.newBooking).subscribe((data) => {
      console.log(data);
      this.bookingService.setValue(this.newBooking)
      this.bookingService.getBookingDetails().subscribe((data:Array<IBooking>)=>{
        console.log(data);
        this.newBookId=Number(data.map(x=>x.bookingId));
        
        this.newPassengerList.forEach((x,index)=>{
          this.indexes.push(index)
        })
        this.indexes.forEach(x=>{
          this.newPassengerList[x].bookId=this.newBookId
        })
        console.log(this.newPassengerList);
        this.newPassengerList.forEach(x=>{
          this.passenger={
            passengerName:x.name,
            seatId:x.seatId,
            bookingId:x.bookId
          }
          this.passengerHttpService.addPassenger(this.passenger).subscribe((data)=>{
            console.log(data);
          })
        })
        this.passengerService.setValue(this.newPassengerList);
      });
    });

    this.newPassengerList
      .map((x) => x.seatId)
      .forEach((x) => {
        this.seat.seatId = x;
        this.seatService.updateSeats(this.seat).subscribe();
      });
  this.router.navigate(['bookdetails/viewticket'])
}
  

  getSelectedSeatValue(event: any) {
    this.seatValue = event.target.value;
    console.log(this.seatValue);
    this.seatValueId = Number(
      this.seats
        .filter((x) => x.seatName === this.seatValue)
        .map((x) => x.seatId)
    );
    console.log(this.seatValueId);
    console.log(this.seats.map((x) => x.seatId));
  }
}
