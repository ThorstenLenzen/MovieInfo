import { Router, Request, Response } from 'express';
import { Movie, MovieRepository } from '../model/movieModel';

export class MovieRouter {

    public router: Router;

    constructor() {
        this.router = Router();
        this.router.get('/', this.getMovies);
    }

    public getMovies(request: Request, response: Response): void {
        MovieRepository.find({ }, (error, movies) => {
            if (error) {
                response.send('400');
            } else {
                response.json(movies);
            }
        });
    }
}