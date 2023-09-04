import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ICoachDetails } from 'src/app/ICoachDetails.Interface';
import { ILoginGet } from 'src/app/ILoginGet.Interface';
import { IStationDetails } from 'src/app/IStationDetails.Interface';
import { CoachHttpService } from 'src/app/coach-http.service';
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
constructor(private stationService:StationHttpService,private router:Router,
  private activatedRoute: ActivatedRoute, private formBuilder: FormBuilder,private coachService:CoachHttpService) {
    this.stationService.getStation().subscribe((data:Array<IStationDetails>)=>{this.station=data;
      console.log(this.station)});
    this.coachService.getCoach().subscribe((coachData:Array<ICoachDetails>)=>{this.coach=coachData;
    console.log(this.coach)});
}
coachData:Array<ICoachDetails>=[]
val:string=''
data:Array<IStationDetails>=[]
fromSearch=new FormGroup({from:new FormControl('')});
toSearch=new FormGroup({to:new FormControl('')});
coachSearch=new FormGroup({coach: new FormControl('')});
ngOnInit(): void {

  
}
onFromSearch()
{
  this.fromSearch.controls['from'].valueChanges.subscribe(value=>{
    console.log(value);
    this.val=value!;
    this.data=this.station.filter(x=>x.stationName.toLocaleLowerCase().includes(this.val.toLocaleLowerCase()));
    console.log(this.data);
  }); 
}
onToSearch(){
  this.toSearch.controls['to'].valueChanges.subscribe(value=>{
    console.log(value);
    this.val=value!;
    this.data=this.station.filter(x=>x.stationName.toLocaleLowerCase().includes(this.val.toLocaleLowerCase()));
    console.log(this.data);
  }); 
}
onCoachSearch(){
this.coachSearch.controls['coach'].valueChanges.subscribe(value=>{
  console.log(value);
  this.val=value!;
  this.coachData=this.coach.filter(x=>x.coachName.toLocaleLowerCase().includes(this.val.toLocaleLowerCase()));
  console.log(this.coachData);
});
}
}