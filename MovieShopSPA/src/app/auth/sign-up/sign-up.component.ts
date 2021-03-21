import { HttpErrorResponse } from '@angular/common/http';
import { ApiService } from './../../core/services/api.service';
import { ValidatorService } from './../../core/services/validator.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { User } from 'src/app/shared/models/user';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  // email = new FormControl('');
  // all Reactive Controls inherit from AbstractControl class
  signupForm!: FormGroup;
  submitted = false;

  constructor(private fb: FormBuilder, private validatorService: ValidatorService
    , private apiService: ApiService) { 
    // Creating form control instances manually can become repetitive when dealing with multiple forms.
    // The FormBuilder service provides convenient methods for generating controls

    // this.signupForm = new FormGroup({
    //   firstName: new FormControl(''),
    //   lastName: new FormControl(''),
    //   email: new FormControl(''),
    //   password: new FormControl(''),
    // });
  }

  // convenience getter for easy access to form fields
  get f() { return this.signupForm.controls; }

  ngOnInit(): void {
     //    console.log(this.email);
    // we can set a value
    // this.email.setValue('test@test.com');
    // console.log(this.signupForm.controls);
    this.buildForm();
  }

  // buildForm() {
  //   this.signupForm = this.fb.group({
  //     firstName: ['Time', Validators.required],
  //     lastName: ['Cook', Validators.required],
  //     email: [null, { validators: [Validators.required, Validators.email], asyncValidators: [this.validatorService.emailExistsValidator()], updateOn: 'blur' }],
  //     password: ['', [Validators.required, this.validatorService.passwordValidator]],
  //     confirmPassword: ['', [Validators.required]]
  //   }, { validators: this.validatorService.passwordMatch });
  // }

   buildForm() {
    this.signupForm = this.fb.group({
      firstName: ['Time', Validators.required],
      lastName: ['Cook', Validators.required],
      email: ['abc789@gmail.com', { validators: [Validators.required, Validators.email], asyncValidators: [this.validatorService.emailExistsValidator()], updateOn: 'blur' }],
      password: ['Qw123456***', [Validators.required, this.validatorService.passwordValidator]],
      confirmPassword: ['Qw123456***', [Validators.required]]
    }, { validators: this.validatorService.passwordMatch });
  }

  onSubmit() {
    // console.log('submit clicked');
    console.log(this.signupForm);
    this.submitted = true;
    // stop here if form is invalid
    if (this.signupForm.invalid) {
      return;
    }

    console.warn(this.signupForm.value)
    this.apiService.create('account/login', this.signupForm.value);
    // .subscribe(
    //   (data) => console.log("Sign up form submitted successfully"),
    //   (error: HttpErrorResponse) => console.log(error)
    // );

    console.log("last line of code in sgn-up component");
  }

}
