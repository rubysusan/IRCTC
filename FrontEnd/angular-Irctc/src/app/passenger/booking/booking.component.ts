import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ICoachDetails } from 'src/app/ICoachDetails.Interface';
import { ILoginGet } from 'src/app/ILoginGet.Interface';
import { IStationDetails } from 'src/app/IStationDetails.Interface';
import { IValuesSearched } from 'src/app/IValuesSearched.Interface';
import { CoachHttpService } from 'src/app/coach-http.service';
import { SearchDetailsService } from 'src/app/search-details.service';
import { StationHttpService } from 'src/app/station-http.service';
import { UserHttpService } from 'src/app/user-http.service';


@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.sass']
})
export class BookingComponent implements OnInit{
station:Array<IStationDetails>=[];
coach:Array<ICoachDetails>=[];
constructor(private searchService:SearchDetailsService,private stationService:StationHttpService,private router:Router,
  private activatedRoute: ActivatedRoute, private formBuilder: FormBuilder,private coachService:CoachHttpService) {
    this.stationService.getStation().subscribe((data:Array<IStationDetails>)=>{this.station=data;
      console.log(this.station)});
    this.coachService.getCoach().subscribe((coachData:Array<ICoachDetails>)=>{this.coach=coachData;
    console.log(this.coach)});
}
coachData:Array<ICoachDetails>=[]
val:string=''
data:Array<IStationDetails>=[]
toData:Array<IStationDetails>=[]
fromSearch=new FormGroup({from:new FormControl('')});
toSearch=new FormGroup({to:new FormControl('')});
coachSearch=new FormGroup({coach: new FormControl('')});
ngOnInit(): void {

  
}
fromStationVal:string=''
onFromSearch()
{
  this.fromSearch.controls['from'].valueChanges.subscribe(value=>{
    this.val=value!;
    this.data=this.station.filter(x=>x.stationName.toLocaleLowerCase().includes(this.val.toLocaleLowerCase()));
    this.fromStationVal=String(this.data.map(x=>x.stationName))
    console.log(this.fromStationVal);
  }); 
}
toStationVal:string=''
onToSearch(){
  this.toSearch.controls['to'].valueChanges.subscribe(value=>{
    this.val=value!;
    this.toData=this.station.filter(x=>x.stationName.toLocaleLowerCase().includes(this.val.toLocaleLowerCase()));
    this.toStationVal=String(this.toData.map(x=>x.stationName))
    console.log(this.toStationVal);
  }); 
}
coachVal:string=''
onCoachSearch(){
this.coachSearch.controls['coach'].valueChanges.subscribe(value=>{
  console.log(value);
  this.val=value!;
  this.coachData=this.coach.filter(x=>x.coachName.toLocaleLowerCase().includes(this.val.toLocaleLowerCase()));
  this.coachVal=String(this.coachData.map(x=>x.coachName))
  console.log(this.coachVal);
});

}
dateVal:Date=new Date()
onDate(event:any)
{
  this.dateVal=event.target.value;
  console.log(this.dateVal)
}
dataSearched:Array<IValuesSearched>=[]
onSearch()
{
 
  this.dataSearched.push(<IValuesSearched>({fromVal:this.fromStationVal,toVal:this.toStationVal,dateVal:this.dateVal,coachVal:this.coachVal}))
  this.searchService.setValue(this.dataSearched)
  this.router.navigate(['./passenger/booking/search']);
}
}