import { 
    Component, 
    OnInit,
    Input
} from '@angular/core';

@Component({
    selector: 'movie-card',
    templateUrl: './app/app/movie-card/movie-card.component.html',
    styleUrls: ['./app/app/movie-card/movie-card.component.css']
})
export class MovieCardComponent {

    @Input()
    public movie: any;
}