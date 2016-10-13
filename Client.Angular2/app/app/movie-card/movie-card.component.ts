import { 
    Component, 
    OnInit,
    Input
} from '@angular/core';

@Component({
    selector: 'movie-card',
    templateUrl: './app/app/movie-card/movie-card.component.html'
})
export class MovieCardComponent {

    @Input()
    public movie: any;
}