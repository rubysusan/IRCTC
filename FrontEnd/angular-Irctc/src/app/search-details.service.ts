import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { IValuesSearched } from './IValuesSearched.Interface';

@Injectable({
  providedIn: 'root'
})
export class SearchDetailsService {

 
  public searchData=new BehaviorSubject<Array<IValuesSearched>>([]);
  search=this.searchData.asObservable();
  
  
    setValue(data:Array<IValuesSearched>)
    {
      this.searchData.next(data);
    }
   
    

}


