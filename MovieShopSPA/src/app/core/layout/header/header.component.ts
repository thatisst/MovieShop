import { AuthService } from './../../services/auth.service';
import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/shared/models/user';
import { Router } from '@angular/router';
import { UserDataService } from '../../services/user-data.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  favoritesCount!: number;
  myMoviesCount!: number;
  currentUser!: User;
  isAuthenticated!: boolean;

  constructor(public authService: AuthService,
    private router: Router, private userDataService: UserDataService) { }

  ngOnInit(): void {
    this.authService.isAuthenticated.subscribe(isAuthenticated => {
      this.isAuthenticated = isAuthenticated;
      if (this.isAuthenticated) {
        this.currentUser = this.userDataService.curentUser;
        this.userDataService.getAllPurchasedMovies();
        this.userDataService.purchasedMovies.subscribe(
          data => {
            if (data) {
              // console.log(data);
              this.myMoviesCount = data.purchasedMovies.length;
            }
          }
        );
      }
    });
  }

  logout() {

    this.authService.logout();
    this.router.navigateByUrl('login');
  }

}
