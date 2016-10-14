import { 
    Component, 
    OnInit
} from '@angular/core';

import { Movie } from '../model';

@Component({
    selector: 'movie-list',
    templateUrl: './app/app/movie-list/movie-list.component.html',
    styleUrls: ['./app/app/movie-list/movie-list.component.css']
})
export class MovieListComponent implements OnInit {

    public movies: Movie[];

    constructor() {

    }

    ngOnInit() {
        this.movies = <Movie[]>[
            {
                name: "Star Wars",
                description: `Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a wookiee and two droids to save the galaxy from 
                              the Empire's world-destroying battle-station, while also attempting to rescue Princess Leia from the evil Darth Vader.`
            }, {
                name: "Sabrina",
                description: `An ugly duckling having undergone a remarkable change, still harbors feelings for her crush: a carefree playboy, but 
                              not before his business-focused brother has something to say about it.`
            }, {
                name: "Patriot Games",
                description: `When CIA Analyst Jack Ryan interferes with an IRA assassination, a renegade faction targets him and his family for revenge.`
            }, {
                name: "Raiders of the lost Ark",
                description: `Archaeologist and adventurer Indiana Jones is hired by the U.S. government to find the Ark of the Covenant before the Nazis.`
            },
        ];
    }
} 