import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { Injectable } from '@angular/core';
import {Genre} from 'src/app/shared/models/genre'

@Injectable({
  providedIn: 'root'
})
export class GenreService {

  constructor(private apiService : ApiService) { }

  getAllGenres(): Observable<Genre[]>{

    // make a call to API to get JSON data and wrap it in Genre array and return
    // we call base ApiService which calls API using HttpClient class
    return this.apiService.getAll('genres');
  }
}
