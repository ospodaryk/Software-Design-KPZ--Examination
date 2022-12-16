import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Movie } from 'src/app/models/movie';
import { MovieService } from 'src/app/services/movie.service';

@Component({
  selector: 'app-edit-movie',
  templateUrl: './edit-movie.component.html',
  styleUrls: ['./edit-movie.component.css']
})
export class EditEmployeeComponent implements OnInit {
  @Input() movie?: Movie;
  @Output() movieUpdated = new EventEmitter<Movie[]>();
  constructor(private movieService: MovieService) { }

  ngOnInit(): void {
  }
  UpdateEmployee(hero: Movie) {
    this.movieService
      .UpdateMovie(hero)
      .subscribe((movie: Movie[]) => this.movieUpdated.emit(movie));
  }

  DeleteEmployee(movie: Movie) {
    this.movieService
      .DeleteMovie(movie)
      .subscribe((movie: Movie[]) => this.movieUpdated.emit(movie));
  }

  AddEmployee(movie: Movie) {
    this.movieService
      .AddMovie(movie)
      .subscribe((movie: Movie[]) => this.movieUpdated.emit(movie));
  }

}
