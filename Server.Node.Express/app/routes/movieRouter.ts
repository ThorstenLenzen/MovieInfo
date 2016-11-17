import { Movie as movie, IMovieModel } from '../dataaccess';
import { BaseMongooseRouter } from'./baseMongooseRouter';

class MovieRouter extends BaseMongooseRouter<IMovieModel> {}

export let movieRouter = new MovieRouter(movie).Router;