import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegisterComponent } from './register/register.component';
import { PassengerComponent } from './passenger/passenger.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { TteComponent } from './tte/tte.component';
import { BookingComponent } from './passenger/booking/booking.component';
import { AccountComponent } from './passenger/account/account.component';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SearchResultsComponent } from './passenger/booking/search-results/search-results.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    PassengerComponent,
    TteComponent,
    BookingComponent,
    AccountComponent,
    SearchResultsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,MatAutocompleteModule,MatInputModule,MatFormFieldModule,BrowserAnimationsModule],
  providers: [BookingComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
