using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Toto.MovieInfo.DataAccess.EF;
using Toto.MovieInfo.PersistenceModel;
using Toto.Utilities.Extensions;

namespace Toto.MovieInfo.DataAccess
{
    public class GetMoviesQueryHandler : IQueryHandler<GetMoviesQuery, ICollection<Movie>>
    {
        private readonly MoviesContext _persistenceContext;

        public GetMoviesQueryHandler(MoviesContext persistenceContext)
        {
            _persistenceContext = persistenceContext;
        }

        public ICollection<Movie> Handle(GetMoviesQuery query)
        {
            if(query == null)
                throw new ArgumentNullException(nameof(query), "Parameter 'query' must not be null.");

            var movies = _persistenceContext
                .Movies
                .AsNoTracking()
                .OrderBy(movie => movie.Name)
                .Skip((query.PageNumber - 1)*query.PageSize)
                .Take(query.PageSize);

            if (query.FullGraph)
            {
                movies = movies
                    .Include(movie => movie.Genre)
                    .Include(movie => movie.MovieActors)
                    .ThenInclude(movieActor => movieActor.Actor);
            }

            var movieList = movies.ToList();

            movieList.ForEach(movie => _persistenceContext.Entry(movie).State = EntityState.Detached);

            return movieList;
        }
    }
}
