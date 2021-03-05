import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { Injectable } from '@angular/core';
import { Purchase } from 'src/app/shared/models/purchase';
import { Purchases } from 'src/app/shared/models/purchases';
import { Favorite } from 'src/app/shared/models/favorite';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private apiService : ApiService) { }

  purchaseMovie(purchase: Purchase) {
    return this.apiService.create('user/purchase', purchase);
  }

  getPurchasedMovies(id: number): Observable<Purchases> {
    return this.apiService.getOne(`${'user/'}${id}${'/purchases'}`);
  }

  favoriteMovie(favorite: Favorite) {
    return this.apiService.create('user/favorite', favorite);
  }

  unfavoriteMovie(favorite: Favorite) {
    return this.apiService.create('user/unfavorite', favorite);
  }

  isMovieFavorited(userId: number, movieId: number): Observable<any> {
    return this.apiService.getOne(`${'user/'}${userId}/movie/${movieId}${'/favorite'}`);
  }

  isEmailExists(email: string): Observable<boolean> {
    const myMap = new Map();
    myMap.set('email', email);
    return this.apiService.getOne('account', null as any, myMap).pipe(map(val => val.emailExists));
  }
}
