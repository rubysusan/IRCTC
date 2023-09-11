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
  public userId=new BehaviorSubject<number>(0);
  idVal=this.userId.asObservable();
  
  public typeId=new BehaviorSubject<number>(0);
  typeVal=this.typeId.asObservable();
  
    setValue(data:Array<IValuesSearched>)
    {
      this.searchData.next(data);
    }
   
    setSelectedValue(data:Array<ISelectedTrain>)
    {
      this.selectData.next(data);
    }
    setUser(id:number,type:number)
    {
      this.userId.next(id)
      this.typeId.next(type)
    }
    

}


