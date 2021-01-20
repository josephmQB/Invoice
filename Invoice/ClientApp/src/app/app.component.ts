import { HttpClient } from '@angular/common/http';
import { Component, Inject, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  public login: boolean;
  public signup: boolean;
  public toggle: boolean = false;
  _http: HttpClient;
  _baseUrl: string;
  @ViewChild('f', { static: false }) signupForm: NgForm;
  userLogin = {
    username: '',
    password: '',
  };
  userSignup = {
    compId: '',
    userId: '',
    email: '',
    active:'',
    username: '',
    password: '',
  };
 constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
   this._http = http;
   this._baseUrl = baseUrl;
   this.login = null;
   this.signup = null;
  }
  signupOrLogin() {
    this.toggle = !this.toggle;
    this.signup = null;
    this.login = null;
  }
  onSubmit() {
    console.log(this.signupForm.value);
    if (this.toggle) {
      /*this.userSignup.compId = this.signupForm.value.compId;
      this.userSignup.userId = this.signupForm.value.userId;
      this.userSignup.email = this.signupForm.value.email;
      this.userSignup.active = this.signupForm.value.active;
      this.userSignup.username = this.signupForm.value.username;
      this.userSignup.password = this.signupForm.value.password;
      //console.log(this.userSignup)*/
      this.signupForm.value.active = this.signupForm.value.active ? true : false; 
      this._http.post<boolean>(this._baseUrl + 'api/signup', this.signupForm.value ).subscribe(result => {
        this.signup = result;
      }, error => console.error(error));
    }
    else {
      /*this.userLogin.username = this.signupForm.value.username;
      this.userLogin.password = this.signupForm.value.password;
      console.log(this.userLogin);*/
      this._http.post<boolean>(this._baseUrl + 'api/login', this.signupForm.value).subscribe(result => {
        this.login = result;
      }, error => console.error(error));
    }
    this.signupForm.reset();
  }
}

