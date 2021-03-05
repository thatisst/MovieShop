import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { Injectable } from '@angular/core';
import { MovieCard } from 'src/app/shared/models/movie-card';
import { Movie } from 'src/app/shared/models/movie';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private apiService: ApiService) { }

  getTopRevenueMovies(): Observable<MovieCard[]> {
    return this.apiService.getAll('movies/toprevenue');
  }

  getMovieById(id:number): Observable<Movie> {
    return this.apiService.getById('movies', id);
  }
}

