import {
    Schema,
    Document,
    model
} from 'mongoose';

import  { IMovie } from '../model';

export interface IMovieModel extends IMovie, Document {}

var movieSchema = new Schema({
    name: String,
    description: String,
    releaseDate: String,
    posterUrl: String
});

export var Movie = model<IMovieModel>('movies', movieSchema);