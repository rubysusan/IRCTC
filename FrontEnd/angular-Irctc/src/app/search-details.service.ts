import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { IValuesSearched } from './IValuesSearched.Interface';
import { ISearchedTrain } from './ISearchedTrain.Interface';
import { ISelectedTrain } from './ISelectedTrain.Interface';

@Injectable({
  providedIn: 'root'
})
export class SearchDetailsService {
  public selectData=new BehaviorSubject<Array<ISelectedTrain>>([]);
  select=this.selectData.asObservable();
 
  public searchData=new BehaviorSubject<Array<IValuesSearched>>([]);
  search=this.searchData.asObservable();
  
  
    setValue(data:Array<IValuesSearched>)
    {
      this.searchData.next(data);
    }
   
    setSelectedValue(data:Array<ISelectedTrain>)
    {
      this.selectData.next(data);
    }
    

}


