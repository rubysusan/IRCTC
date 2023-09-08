import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ILoginDetails } from '../ILoginDetails.Interface';
import { UserHttpService } from '../user-http.service';

enum userTypeEnum {
  Passenger = 1,
  TTE,
}

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.sass'],
})
export class RegisterComponent implements OnInit {
  selectedValue: any;
  typeValue: number = 0;
  public newUser: ILoginDetails = {
    userName: '',
    password: '',
    email: '',
    identityCardID: '',
    userTypeID: 0,
  };
  public regGroup!: FormGroup;
  constructor(
    private userService: UserHttpService,
    private fb: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {}
  ngOnInit() {
    this.regGroup = this.fb.group({
      userName: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required]),
      identityCardID: new FormControl('', [Validators.required]),
      userType: new FormControl('',[Validators.required]),
    });
  }
  getSelectedValue(event: any) {
    this.selectedValue = event.target.value;
    if (this.selectedValue === userTypeEnum[userTypeEnum.Passenger]) {
      this.typeValue = userTypeEnum.Passenger;
    } else {
      this.typeValue = userTypeEnum.TTE;
    }
    console.log(this.typeValue);
    console.log(event.target.value);
  }

  insert() {
    if (this.regGroup.valid) {
      const val = this.regGroup.value;
      const temp: ILoginDetails = {
        userName: val.userName,
        password: val.password,
        email: val.email,
        identityCardID: val.identityCardID,
        userTypeID: this.typeValue,
      };
      this.newUser={
        userName:temp.userName,
        password :temp.password,
        email:temp.email,
        identityCardID:temp.identityCardID,
        userTypeID:temp.userTypeID
      }
      // this.newUser.userName = temp.userName;
      // this.newUser.password = temp.password;
      // this.newUser.email = temp.email;
      // this.newUser.identityCardID = temp.identityCardID;
      // this.newUser.userTypeID = temp.userTypeID;
      this.userService.addUser(this.newUser).subscribe((data) => {
        console.log(data);
      });
      alert('Successfully Registered');
      this.router.navigate(['login']);
    }
  
  }
  onBack() {
    this.router.navigate(['login']);
  }
}
