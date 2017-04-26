import { MovieOverview } from './../movie-model/movie-overview';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'toto-movie-card',
  templateUrl: './movie-card.component.html',
  styleUrls: ['./movie-card.component.less']
})
export class MovieCardComponent {
  @Input() movie: MovieOverview;
}
