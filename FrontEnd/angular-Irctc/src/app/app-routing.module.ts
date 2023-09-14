import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { PassengerComponent } from './passenger/passenger.component';
import { TteComponent } from './tte/tte.component';
import { BookingComponent } from './passenger/booking/booking.component';
import { AccountComponent } from './passenger/account/account.component';
import { SearchResultsComponent } from './passenger/booking/search-results/search-results.component';
import { BookDetailsComponent } from './book-details/book-details.component';
import { TteAccountComponent } from './tte/tte-account/tte-account.component';
import { TteSearchComponent } from './tte/tte-search/tte-search.component';
import { TteTrainsComponent } from './tte/tte-search/tte-trains/tte-trains.component';
import { ViewTicketComponent } from './view-ticket/view-ticket.component';
import { TtePassengerViewComponent } from './tte-passenger-view/tte-passenger-view.component';

const routes: Routes = [
  {
  path:'login',component:LoginComponent
  },
  {
    path:'bookdetails',children:[
      {
        path:'',component:BookDetailsComponent
      },
      {
        path:'viewticket',component:ViewTicketComponent
      }
    ]
    
  },
  {
    path:'register',component:RegisterComponent
  },
  {
    path:'passenger',children:[
      {
        path:'',component:PassengerComponent
      },
      {
        path:'booking',children:[
          {
            path:'',component:BookingComponent
          },
          {path:'search',component:SearchResultsComponent}
        ]
      },
      {
        path:'account',component:AccountComponent
      }
    ]
  },
  {
    path:'tte',children:[
      {
        path:'',component:TteComponent 
      },
      {
        path:'account',component:TteAccountComponent
      },
      {
        path:'search',children:[
          {
            path:'',component:TteSearchComponent
          },
          {
            path:'view-trains',children:[
              {
                path:'',component:TteTrainsComponent
              },
              {
                path:'view-passenger',component:TtePassengerViewComponent
              }
            ] 
            
          }
        ] 
      }
    ]
  },
  {
     path: '', redirectTo: '/login', pathMatch: 'full'
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
