import { Component, OnInit } from '@angular/core';
import { SearchDetailsService } from '../search-details.service';
import { Subscription } from 'rxjs';
import { ISelectedTrain } from '../ISelectedTrain.Interface';

@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.sass']
})
export class BookDetailsComponent implements OnInit{
  
  subs?:Subscription ;
  selectVal:Array<ISelectedTrain>=[];
  constructor(private searchService:SearchDetailsService) {
    this.subs=this.searchService.select.subscribe((x:Array<ISelectedTrain>) => this.selectVal=x)
    console.log(this.selectVal)
    
  }
  
  ngOnInit(): void {
   
  }

}
