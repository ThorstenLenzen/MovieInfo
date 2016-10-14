import {
    Component,
    Input
} from '@angular/core';

import { Movie } from '../model';

@Component({
    selector: 'movie-card',
    templateUrl: './app/app/movie-card/movie-card.component.html',
    styleUrls: ['./app/app/movie-card/movie-card.component.css']
})
export class MovieCardComponent {

    @Input()
    public movie: Movie;
}