import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { ISearchedTrain } from 'src/app/ISearchedTrain.Interface';
import { ISeatDetails } from 'src/app/ISeatDetails.Interface';
import { ISelectedTrain } from 'src/app/ISelectedTrain.Interface';
import { IValuesSearched } from 'src/app/IValuesSearched.Interface';
import { AvailableSeatHttpService } from 'src/app/available-seat-http.service';
import { ChargeHttpService } from 'src/app/charge-http.service';
import { PassengerHttpService } from 'src/app/passenger-http.service';
import { BookingComponent } from 'src/app/passenger/booking/booking.component';
import { SearchDetailsService } from 'src/app/search-details.service';
import { TrainsSearchHttpService } from 'src/app/trains-search-http.service';
import { TraintypeHttpService } from 'src/app/traintype-http.service';
interface IChargeValue {
  charge: number;
}
enum trainTypeEnum{
  Janshatabdi=1,
        Shatabdi,
        Antyodaya,
        Intercity,
        Express
}
enum coachEnum{
  ACFirstClass=1,
        ExecChairCar,
        ACChairCar,
        Sleeper,
        SecondSitting,
        ACSecondTier,
        ACThirdTier,
        ACThreeEconomy
}
@Component({
  selector: 'app-tte-trains',
  templateUrl: './tte-trains.component.html',
  styleUrls: ['./tte-trains.component.sass']
})
export class TteTrainsComponent {
  seat: Array<ISeatDetails> = [];
  searchVal: Array<IValuesSearched> = [];
  subs?: Subscription;
  searchDate: string = '';
  from: number = 0;
  to: number = 0;
  dateVal: string = '';
  coach: number = 0;
  selectedTrain: Array<ISelectedTrain> = [];

  train: Array<ISearchedTrain> = [];
  trainDepartEF: Array<ISearchedTrain> = [];
  trainDepartLF: Array<ISearchedTrain> = [];
  trainArrivalEF: Array<ISearchedTrain> = [];
  trainArrivalLF: Array<ISearchedTrain> = [];

  constructor(
    private seatService: AvailableSeatHttpService,
    private trainService: TrainsSearchHttpService,
    private searchService: SearchDetailsService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private booking: BookingComponent,
    private chargeService: ChargeHttpService,
    private trainTypeService: TraintypeHttpService,
    private passengerHttpService:PassengerHttpService
  ) {}

  ngOnInit(): void {
 

    this.subs = this.searchService.search.subscribe(
      (x: Array<IValuesSearched>) => (this.searchVal = x)
    );
    console.log(this.searchVal);
    this.from = Number(this.searchVal.map((x) => x.fromVal));
    this.to = Number(this.searchVal.map((x) => x.toVal));
    this.dateVal = String(this.searchVal.map((x) => x.dateVal));
    this.coach = Number(this.searchVal.map((x) => x.coachVal));

    this.trainService
    .getTrainBySearch(
      this.from,
      this.to,
      this.dateVal + 'T00:00:00',
      this.coach
    )
    .subscribe((data: Array<ISearchedTrain>) => {
      this.train = data;
      console.log(this.train);
    });
  }
  id: number = 0;
  tname: string = '';
  fromStat: string = '';
  fromStatId:number=0;
  toStat: string = '';
  toStatId:number=0;
  depart: string = '';
  arriv: string = '';
  coachVal:string='';
  coachValId: number = 0;
  tdate: string = '';
  cost:Array<IChargeValue>=[]


  dateSearched: Date = new Date();
  onFilterDate(event: any) {
    this.dateVal = event.target.value;
    console.log(this.dateSearched);
    this.trainService
      .getTrainBySearch(
        this.from,
        this.to,
        this.dateVal + 'T00:00:00',
        this.coach
      )
      .subscribe((data: Array<ISearchedTrain>) => {
        this.train = data;
        console.log(this.train);
      });
  }



  trainTypeSearched: string = '';
  trainTypeValue:number=0;



  getSelectedTrainType(event: any) {
    this.trainTypeSearched = event.target.value;
    console.log(this.trainTypeSearched);
    if(this.trainTypeSearched==trainTypeEnum[trainTypeEnum.Antyodaya])
    {
      this.trainTypeValue=trainTypeEnum.Antyodaya
    }
    else if(this.trainTypeSearched==trainTypeEnum[trainTypeEnum.Express])
    {
      this.trainTypeValue=trainTypeEnum.Express
    }
    else if(this.trainTypeSearched==trainTypeEnum[trainTypeEnum.Intercity])
    {
      this.trainTypeValue=trainTypeEnum.Intercity
    }
    else if(this.trainTypeSearched==trainTypeEnum[trainTypeEnum.Janshatabdi])
    {
      this.trainTypeValue=trainTypeEnum.Janshatabdi
    }
    else if(this.trainTypeSearched==trainTypeEnum[trainTypeEnum.Shatabdi])
    {
      this.trainTypeValue=trainTypeEnum.Shatabdi
    }
    this.trainTypeService
      .getTrainByType(
        this.from,
        this.to,
        this.dateVal,
        this.coach,
        this.trainTypeValue
      )
      .subscribe((data: Array<ISearchedTrain>) => {
        this.train = data;
        console.log(this.train);
      });
  }



  classId:number=0;
  classSearched: string = '';


  getSelectedClass(event: any) {
    this.classSearched = event.target.value;
    console.log(this.classSearched);
    if(this.classSearched==coachEnum[coachEnum.ACChairCar])
    {
      this.classId=coachEnum.ACChairCar
    }
    else if(this.classSearched==coachEnum[coachEnum.ACFirstClass])
    {
      this.classId=coachEnum.ACFirstClass
    }
    else if(this.classSearched==coachEnum[coachEnum.ACSecondTier])
    {
      this.classId=coachEnum.ACSecondTier
    }
    else if(this.classSearched==coachEnum[coachEnum.ACThirdTier])
    {
      this.classId=coachEnum.ACThirdTier
    }
    else if(this.classSearched==coachEnum[coachEnum.ACThreeEconomy])
    {
      this.classId=coachEnum.ACThreeEconomy
    }
    else if(this.classSearched==coachEnum[coachEnum.ExecChairCar])
    {
      this.classId=coachEnum.ExecChairCar
    }
    else if(this.classSearched==coachEnum[coachEnum.SecondSitting])
    {
      this.classId=coachEnum.SecondSitting
    }
    else if(this.classSearched==coachEnum[coachEnum.Sleeper])
    {
      this.classId=coachEnum.Sleeper
    }
    this.trainService
      .getTrainBySearch(this.from, this.to, this.dateVal, this.classId)
      .subscribe((data: Array<ISearchedTrain>) => {
        this.train = data;
        console.log(this.train);
      });
  }
  charge:Array<IChargeValue>= [];


  onSeat(coach: number,name:string) {
    console.log(coach)
    this.coachValId = coach;
    this.coachVal=name;
    this.chargeService
      .getCharge(this.id, this.from, this.to, this.coachValId)
      .subscribe((data: Array<IChargeValue>) => {
        this.charge = data;
        console.log(this.charge);
        this.chargeService.setChargeValue(this.charge);
      });
    
  }

  onDepartureEF(event: any) {
    console.log(event.target.value);
    if (event.target.value == 'DepartureEF') {
      this.train ==
        this.train
          .filter((x) => x.trainId)
          .sort((a, b) => 0 - (a > b ? -1 : 1));
      this.trainDepartEF = this.train
        .filter((x) => x.departureTime)
        .sort((a, b) => 0 - (a > b ? -1 : 1));
      this.train = this.trainDepartEF;
      console.log(this.train);
    } else if (event.target.value == 'DepartureLF') {
      this.train = this.train
        .filter((x) => x.trainId)
        .sort((a, b) => 0 - (a > b ? -1 : 1));
      this.trainDepartLF = this.train
        .filter((x) => x.departureTime)
        .sort((a, b) => 0 - (a > b ? 1 : -1));
      this.train = this.trainDepartLF;
      console.log(this.train);
    } else if (event.target.value == 'ArrivalEF') {
      this.train = this.train
        .filter((x) => x.trainId)
        .sort((a, b) => 0 - (a > b ? -1 : 1));
      this.trainArrivalEF = this.train
        .filter((x) => x.reachingTime)
        .sort((a, b) => 0 - (a > b ? -1 : 1));
      this.train = this.trainArrivalEF;
      console.log(this.train);
    } else if (event.target.value == 'ArrivalLF') {
      this.train = this.train
        .filter((x) => x.trainId)
        .sort((a, b) => 0 - (a > b ? -1 : 1));
      this.trainArrivalLF = this.train
        .filter((x) => x.reachingTime)
        .sort((a, b) => 0 - (a > b ? 1 : -1));
      this.train = this.trainArrivalLF;
      console.log(this.train);
    }
  }

  onPassenger(trainId:number)
  {
    this.passengerHttpService.setValue(trainId);
    this.router.navigate(['tte/search/view-trains/view-passenger'])
  }

}
