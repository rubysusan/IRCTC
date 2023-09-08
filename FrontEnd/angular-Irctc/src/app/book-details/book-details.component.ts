import { Component, OnInit } from '@angular/core';
import { SearchDetailsService } from '../search-details.service';
import { Subscription } from 'rxjs';
import { ISelectedTrain } from '../ISelectedTrain.Interface';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.sass'],
})
export class BookDetailsComponent implements OnInit {
  public passengerGroup!: FormGroup;
  subs?: Subscription;
  selectVal: Array<ISelectedTrain> = [];
  selectedValue: string = '';
  view?: Boolean;

  constructor(
    private searchService: SearchDetailsService,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.passengerGroup = this.fb.group({
      passengerName: new FormControl(''),
      passengerAge: new FormControl(''),
      passengeGender: new FormControl(''),
      preference: new FormControl(''),
    });

    this.subs = this.searchService.select.subscribe(
      (x: Array<ISelectedTrain>) => (this.selectVal = x)
    );
    console.log(this.selectVal);
  }
  getSelectedValue(event: any) {
    this.selectedValue = event.target.value;
  }
  addPassenger() {
    this.view = true;
  }
  add() {
    this.view = false;
  }
}
