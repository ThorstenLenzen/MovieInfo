import { Movie } from './movie';

describe('Movie', () => {
  let movie: Movie;

  beforeEach(() => {
    movie = new Movie();
    movie.name = 'Movie Name';
    movie.description = 'Movie Description';
    movie.releaseDate = '1980';
    movie.posterUrl = 'http://url.com/poster';

  });

  it('should create', () => {
    expect(movie).toBeTruthy();
  });
});
