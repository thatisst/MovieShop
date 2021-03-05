import { AuthService } from './auth.service';
import { UserService } from './user.service';
import { Injectable } from '@angular/core';
import { User } from 'src/app/shared/models/user';
import { BehaviorSubject } from 'rxjs';
import { Purchases } from 'src/app/shared/models/purchases';

@Injectable({
  providedIn: 'root'
})
export class UserDataService {

  isAuthenticated!: boolean;
  curentUser!: User;

  private purchasedMoviesSubject = new BehaviorSubject<Purchases>(null as any);
  purchasedMovies = this.purchasedMoviesSubject.asObservable();

  constructor(private userService: UserService,
    private authService: AuthService) { 
      this.authService.isAuthenticated.subscribe(
        isAuthenticated => {
          this.isAuthenticated = isAuthenticated;
          if (this.isAuthenticated) {
            this.authService.currentUser.subscribe(
              (user: User) => {
                this.curentUser = user;
              });
          }
        });
    }

  getAllPurchasedMovies() {
    this.userService.getPurchasedMovies(this.curentUser.nameid)
    .subscribe(m => this.purchasedMoviesSubject.next(m));
  }

}
