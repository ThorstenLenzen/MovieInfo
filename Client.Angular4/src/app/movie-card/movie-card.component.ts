import { Component, Input } from '@angular/core';

import { Movie } from '../movie-model';

@Component({
  selector: 'toto-movie-card',
  templateUrl: './movie-card.component.html',
  styleUrls: ['./movie-card.component.less']
})
export class MovieCardComponent {
  @Input() movie: Movie;
}
