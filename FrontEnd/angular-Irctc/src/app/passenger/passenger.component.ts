import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-passenger',
  templateUrl: './passenger.component.html',
  styleUrls: ['./passenger.component.sass'],
})
export class PassengerComponent {
  constructor(private router: Router, private activatedRoute: ActivatedRoute) {}
  onBook() {
    this.router.navigate(['passenger/booking']);
  }
  onAccountClick() {
    this.router.navigate(['passenger/account']);
  }
}
