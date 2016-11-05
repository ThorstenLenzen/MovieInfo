import * as mongoose from 'mongoose';

export var movieSchema = new mongoose.Schema({
    name: String,
    description: String,
    releaseDate: String,
    posterUrl: String
});

export interface Movie extends mongoose.Document {
    name: string;
    description: string;
    releaseDate: string;
    posterUrl: string;
}

export var movieRepository = mongoose.model<Movie>('movies', movieSchema);