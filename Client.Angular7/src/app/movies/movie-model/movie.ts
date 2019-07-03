import { Actor } from "./actor";
import { Genre } from "./genre";
import { Poster } from "./poster";

export interface Movie {
    id: string;
    name: string;
    description: string;
    releaseDate: string;
    rating: number;
    poster: Poster;
    genre: Genre;
    actors: Actor[];
}