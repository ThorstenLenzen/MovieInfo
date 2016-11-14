import { Router, Request, Response } from 'express';
import { Movie } from '../dataaccess';
import { IMovie } from '../model';

export class MovieRouter {

    public router: Router;

    constructor() {
        this.router = Router();

        this.router.get('/', this.getMovies);
        this.router.get('/:id', this.getMovieById);
        this.router.post('/', this.createMovie);
        this.router.put('/:id', this.updateMovie);
        this.router.patch('/:id', this.updateMovie);
        this.router.delete('/:id', this.deleteMovie);
    }

    // GET /movie
    private getMovies(request: Request, response: Response): void {
        Movie.find({ }, (error, movies) => {
            if (error) {
                response.status(500).json(error);
            } else {
                response.status(200).json(movies);
            }
        });
    }

    // GET /movie/5804c380c28a3bc7eaeab26a
    private getMovieById(request: Request, response: Response): void {
        Movie.findById(request.params['id'], (error, movies) => {
            if (error) {
                response.status(500).json(error);
            } else {
                response.status(200).json(movies);
            }
        });
    }

    // POST /movie
    private createMovie(request: Request, response: Response): void {
        let movie = new Movie(request.body);

        movie.save((error, movie) => {
            if (error) {
                response.status(500).json(error);
            } else {
                response.status(200).json(movie);
            }
        });

        response.status(200);
    }

    // PUT /movie/5804c380c28a3bc7eaeab26a
    // PATCH /movie/5804c380c28a3bc7eaeab26a
    private updateMovie(request: Request, response: Response): void {
        Movie.findOneAndUpdate({_id: request.params['id']}, request.body, (error, movie) => {
            if (error) {
                response.status(500).json(error);
            } else {
                response.status(200).json(movie);
            }
        });
    }

    private deleteMovie(request: Request, response: Response): void {
        Movie.remove({_id: request.params['id']}, error => {
            if (error) {
                response.status(500).json(error);
            } else {
                response.status(200);
            }
        });
    }
}