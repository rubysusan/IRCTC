import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ILoginGet } from 'src/app/ILoginGet.Interface';
import { IStationDetails } from 'src/app/IStationDetails.Interface';
import { StationHttpService } from 'src/app/station-http.service';
import { UserHttpService } from 'src/app/user-http.service';


@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.sass']
})
export class BookingComponent implements OnInit{
station:Array<IStationDetails>=[]
constructor(private stationService:StationHttpService,private router:Router,
  private activatedRoute: ActivatedRoute, private formBuilder: FormBuilder) {
    this.stationService.getStation().subscribe((data:Array<IStationDetails>)=>{this.station=data;
      console.log(this.station)})
}
val:string=''
data:Array<IStationDetails>=[]
fromSearch=new FormGroup({from:new FormControl('')});
toSearch=new FormGroup({to:new FormControl('')});
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
}
