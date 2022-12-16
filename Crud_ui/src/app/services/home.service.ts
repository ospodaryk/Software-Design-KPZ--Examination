import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Movie } from '../models/movie';

@Injectable({
  providedIn: 'root'
})
export class HomeService {
  private url="Movies";
  constructor(private http:HttpClient) { }

  
  public GetMoviesList(): Observable<Movie[]> {
    return this.http.get<Movie[]>(`${environment.apiUrl}/${this.url}`);
  }
  
  public UpdateMovie(movie: Movie): Observable<Movie[]> {
    return this.http.put<Movie[]>(
      `${environment.apiUrl}/${this.url}`,
      movie
    );
  }

  public AddMovie(movie: Movie): Observable<Movie[]> {
    return this.http.post<Movie[]>(
      `${environment.apiUrl}/${this.url}`,
      movie
    );
  }

  public DeleteEmployee(hero: Movie): Observable<Movie[]> {
    return this.http.delete<Movie[]>(
      `${environment.apiUrl}/${this.url}/${hero.idMovie}`
    );
  }
}
