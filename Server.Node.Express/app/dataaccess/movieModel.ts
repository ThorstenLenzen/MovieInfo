import {
    Schema,
    Document,
    model
} from 'mongoose';
import  { IMovie } from '../model';

interface IMovieModel extends IMovie, Document {
    name: string;
    description: string;
    releaseDate: string;
    posterUrl: string;
}

var movieSchema = new Schema({
    name: String,
    description: String,
    releaseDate: String,
    posterUrl: String
});

export var Movie = model<IMovieModel>('movies', movieSchema);