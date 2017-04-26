import { MovieOverview, Movie } from '../movie-model';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';

@Injectable()
export class MovieService {

  constructor(private http: Http) { }

  public getAllMovies(): Array<Movie> {
    return [
      <Movie>{
        name: 'Star Wars',
        description: 'Luke Skywalker, a young farmer from the desert planet ' +
                     'of Tattooine, must save Princess Leia from the evil Darth Vader.',
        releaseDate: '1977',
        rating: 4 },
      <Movie>{
        name: 'Sabrina',
        description: 'An ugly duckling having undergone a remarkable change, still harbors feelings for her ' +
                     'crush: a carefree playboy, but not before his business-focused brother has something to say about it.',
        releaseDate: '1995',
        rating: 3 },
      <Movie>{
        name: 'Patriot Games',
        description: 'When CIA Analyst Jack Ryan interferes with an IRA assassination, ' +
                     'a renegade faction targets him and his family for revenge.',
        releaseDate: '1992',
        rating: 5 },
      <Movie>{
        name: 'Blade Runner',
        description: 'A blade runner must pursue and try to terminate four replicants ' +
                     'who stole a ship in space and have returned to Earth to find their creator.',
        releaseDate: '1982',
        rating: 0 }
    ];
  }

  public getAllMovieOverviews(): Observable<MovieOverview[]> {
    const subject = new Subject<MovieOverview[]>();

    this.http.get('assets/poster.json').subscribe(data => {
      const overviews = [
        <MovieOverview>{
          name: 'Raiders of the Lost Ark',
          releaseDate: '1981',
          rating: 4,
          thumbnail: data.json().raiders
        },
        <MovieOverview>{
          name: 'Star Wars',
          releaseDate: '1977',
          rating: 4,
          thumbnail: data.json().raiders
        },
        <MovieOverview>{
          name: 'Sabrina',
          releaseDate: '1995',
          rating: 3,
          thumbnail: data.json().raiders
         },
        <MovieOverview>{
          name: 'Patriot Games',
          releaseDate: '1992',
          rating: 5,
          thumbnail: data.json().raiders
         },
        <MovieOverview>{
          name: 'Blade Runner',
          releaseDate: '1982',
          rating: 0,
          thumbnail: data.json().raiders
         }
      ];

      subject.next(overviews);
      subject.complete();
    });

    return subject;
  }

}
