import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class JwtStorageService {

  token! : string;

  constructor() { }

  // getToken(): string {
  //   this.token = JSON.parse(localStorage.getItem('token') || '{}');
  //   console.log(localStorage.getItem('token'));
  //   return this.token;
  // }

  getToken(): string {
    return localStorage.getItem('token') as any;
  }

  saveToken(token: string) {
    localStorage.setItem('token', token);
  }

  destroyToken() {
    localStorage.removeItem('token');
  }

}
