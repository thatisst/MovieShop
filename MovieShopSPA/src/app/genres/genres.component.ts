import { GenreService } from './../core/services/genre.service';
import { ApiService } from './../core/services/api.service';
import { Component, OnInit } from '@angular/core';
import { Genre } from '../shared/models/genre';

@Component({
  selector: 'app-genres',
  templateUrl: './genres.component.html',
  styleUrls: ['./genres.component.css']
})
export class GenresComponent implements OnInit {

  // this property will be available to view so that it can use to display data
  genres : Genre[] = [];

  constructor(private genreService : GenreService) { }

  ngOnChanges(){
    console.log('inside ngOnChanges method');

  }
  // this is where we call API to get the data
  ngOnInit(): void {
    console.log('inside ngOnInit method');
    this.genreService.getAllGenres().subscribe(
      g => {
        this.genres = g;
        console.log('genres')
      }
    );
  }

  ngOnDestroy(){
    console.log('inside ngOnDestroy method');

  }

}
