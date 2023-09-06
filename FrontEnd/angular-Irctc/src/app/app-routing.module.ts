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

const routes: Routes = [
  {
  path:'',component:LoginComponent
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
    path:'tte',component:TteComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
