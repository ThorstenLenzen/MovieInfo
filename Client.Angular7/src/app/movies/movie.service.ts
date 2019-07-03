import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, pipe } from 'rxjs';
import { map } from 'rxjs/operators';

import { Movie } from './movie-model/movie';
import { MovieOverview } from './movie-model/movie-overview';

@Injectable()
export class MovieService {

  constructor(private httpClient: HttpClient) { }

  public getAllMovies(): Observable<Movie[]> {
    return this.httpClient
    .get('./assets/movie-data.json')
    .pipe(map(data => (<any>data).movies));
  }

  public getAllMovieOverviews(): Observable<MovieOverview[]> {
    return this.httpClient
    .get('./assets/movie-data.json')
    .pipe(map(data => {
      const movies = (<any>data).movies as Movie[];
      const movieOverviews: MovieOverview[] = [];

      movies.forEach(item => {
        let movieOverview: MovieOverview = {
          id: item.id,
          name: item.name,
          releaseDate: item.releaseDate,
          genre: item.genre.name
        };
        
        movieOverviews.push(movieOverview);
      });

      return movieOverviews;
    }));
  }
}
