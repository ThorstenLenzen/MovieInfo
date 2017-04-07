import { Movie } from '../movie-model';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'toto-movie-dashboard',
  templateUrl: './movie-dashboard.component.html',
  styleUrls: ['./movie-dashboard.component.css']
})
export class MovieDashboardComponent implements OnInit {
  public movies: Array<Movie>;

  ngOnInit() {
    // movies =
  }

}
