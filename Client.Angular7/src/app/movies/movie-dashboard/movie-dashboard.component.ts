import { Component, OnInit } from '@angular/core';
import { MovieService } from '../movie.service';
import { MovieOverview } from '../movie-model/movie-overview';

@Component({
  templateUrl: './movie-dashboard.component.html',
  styleUrls: ['./movie-dashboard.component.scss']
})
export class MovieDashboardComponent implements OnInit {

  public movies: MovieOverview[];

  constructor(private movieService: MovieService) { }

  ngOnInit() {
    this.movieService
      .getAllMovieOverviews()
      .subscribe(movies => {
        this.movies = movies;
      })
  }

}
