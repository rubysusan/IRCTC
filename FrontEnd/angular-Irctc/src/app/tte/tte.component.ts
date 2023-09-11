import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tte',
  templateUrl: './tte.component.html',
  styleUrls: ['./tte.component.sass']
})
export class TteComponent {
  constructor(private router:Router){

  }
  onSearchTrain(){

  }
  onMyAccount(){
    this.router.navigate(['tte/account'])
  }
}
