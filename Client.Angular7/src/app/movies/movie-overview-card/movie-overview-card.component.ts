import { Component, Input } from '@angular/core';
import { MovieOverview } from '../movie-model/movie-overview';

@Component({
  selector: 'toto-movie-overview-card',
  templateUrl: './movie-overview-card.component.html',
  styleUrls: ['./movie-overview-card.component.scss']
})
export class MovieOverviewCardComponent {

  @Input() movie: MovieOverview;
  
}
