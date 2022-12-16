import { Component } from '@angular/core';
import { Movie } from './models/movie';
import { MovieService } from './services/movie.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Crud_ui';
  movies:Movie[]=[];
  movieToEdit?: Movie;
  movieToRecommend?: Movie;

  constructor(private movieService:MovieService){}

  ngOnInit() : void{
  this.movieService
    .GetMoviesList()
    .subscribe((result:Movie[])=>(this.movies=result));
  }
 

  AddMovie() {
    this.movieToEdit = new Movie();
  }

  UpdateMoviesList(movies: Movie[]) {
    this.movies = movies;
  }
  
  RecomendMovie(movie: Movie) {
    movie.recomendation=!movie.recomendation;
    this.movieService
        .UpdateMovie(movie);
  }
  UpdateMovie(movie: Movie) {
    this.movieToEdit = movie;
  }

}
