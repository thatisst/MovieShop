import { BehaviorSubject, Observable } from 'rxjs';
import { Login } from 'src/app/shared/models/login';
import { JwtStorageService } from './jwt-storage.service';
import { ApiService } from './api.service';
import { Injectable } from '@angular/core';
import { User } from 'src/app/shared/models/user';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private user!: User;
  private currentUserSubject = new BehaviorSubject<User>({} as User);
  public currentUser = this.currentUserSubject.asObservable();

  private isAuthenticatedSubject = new BehaviorSubject<boolean>(false);
  public isAuthenticated = this.isAuthenticatedSubject.asObservable();


  constructor(private apiService: ApiService,
    private jwtStorageService: JwtStorageService) { }

  login(userLogin : Login): Observable<boolean>{
    return this.apiService.create('account/login', userLogin)
      .pipe(map((response => {
        if (response) {
          this.jwtStorageService.saveToken(response.token);
          this.populateUserInfo();
          return true;
        }
        return false;
      })));
  }

  populateUserInfo() {
    if (this.jwtStorageService.getToken()) {
      const token = this.jwtStorageService.getToken();
      const decodedToken = this.decodedToken();
      this.currentUserSubject.next(decodedToken);
      this.isAuthenticatedSubject.next(true);
    }
  }

  private decodedToken(): User {
    const token = this.jwtStorageService.getToken();
    if (!token || new JwtHelperService().isTokenExpired(this.jwtStorageService.getToken())) {
      this.logout();
      return null as any;
    }
    const decodedToken = new JwtHelperService().decodeToken(token);
    this.user = decodedToken;
    return this.user;
  }

  logout() {
    // Remove JWT from localstorage
    this.jwtStorageService.destroyToken();
    // Set current user to an empty object
    this.currentUserSubject.next({} as User);
    // Set auth status to false
    this.isAuthenticatedSubject.next(false);

  }

  getCurrentUser(): User {
    return this.currentUserSubject.value;
  }
}
