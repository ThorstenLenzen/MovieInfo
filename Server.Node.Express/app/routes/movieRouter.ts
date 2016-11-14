import { Router, Request, Response } from 'express';
import { Movie } from '../dataaccess';

export class MovieRouter {

    public router: Router;

    constructor() {
        this.router = Router();

        this.router.get('/', this.getMovies);
        this.router.get('/:id', this.getMovieById);
        this.router.post('/', this.createMovie);
    }

    //movie/
    public getMovies(request: Request, response: Response): void {
        Movie.find({ }, (error, movies) => {
            if (error) {
                response.status(400);
            } else {
                response.status(200).json(movies);
            }
        });
    }

    //movie/5804c380c28a3bc7eaeab26a
    public getMovieById(request: Request, response: Response): void {
        Movie.findById(request.params['id'], (error, movies) => {
            if (error) {
                response.status(400);
            } else {
                response.status(200).json(movies);
            }
        });
    }

    public createMovie(request: Request, response: Response): void {
        // let movie = new 
        // movieRepository.create(movie, (error, movies) => {

        // });
        response.status(200);
    }
}