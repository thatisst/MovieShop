import { AuthService } from './../../core/services/auth.service';
import { Component, OnInit } from '@angular/core';
import { Login } from 'src/app/shared/models/login';
import { User } from 'src/app/shared/models/user';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  invalidLogin!: boolean;
  returnUrl!: string;
  user!: User;
  userLogin: Login = {
    email: '', password: ''
  }

  constructor(private authService: AuthService,
    private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(
      params => this.returnUrl = params.returnUrl || '/'
    );
    // console.log("Inside ngOnInit UN/PW");
    // console.log(this.userLogin.email);
    // console.log(this.userLogin.password);
  }

  login() {
    this.authService.login(this.userLogin)
      .subscribe((response) => {
        if (response) {
          // console.log(' this is returnURL: ' + this.returnUrl);
          this.router.navigate([this.returnUrl]);
        } else {
          this.invalidLogin = true;
        }
      },
        (err: any) => { this.invalidLogin = true, console.log(err); });
        
    // console.log("Inside On Click UN/PW");
    // console.log(this.userLogin.email);
    // console.log(this.userLogin.password);
    console.log("Form is submitted!");
  }

}
