import { MovieService } from './../../core/services/movie.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Movie } from 'src/app/shared/models/movie';


@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {
  
  movie!: Movie;
  id: number = 0;
  constructor(private route: ActivatedRoute,
    private movieService: MovieService) { }

  ngOnInit(): void {
    console.log("ngOnInit movie details");
    this.id =  this.route.snapshot.params['id'];

    this.movieService.getMovieById(this.id).subscribe(
      m => {
        this.movie = m;
        console.log(this.movie);
      }
    );

  }

}
