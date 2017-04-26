import { MovieOverview } from './../movie-model';
import { MovieService } from './../movie-services/movie.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'toto-movie-dashboard',
  templateUrl: './movie-dashboard.component.html',
  styleUrls: ['./movie-dashboard.component.less']
})
export class MovieDashboardComponent implements OnInit {
  public movies: Array<MovieOverview>;

  constructor(private movieService: MovieService) { }

  ngOnInit() {
    this.movieService.getAllMovieOverviews().subscribe(movies => {
      this.movies = movies;
    });
  }
}
