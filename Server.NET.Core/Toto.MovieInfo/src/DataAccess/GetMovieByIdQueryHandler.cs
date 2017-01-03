using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Toto.MovieInfo.DataAccess.EF;
using Toto.MovieInfo.PersistenceModel;

namespace Toto.MovieInfo.DataAccess
{
    public class GetMovieByIdQueryHandler : IQueryHandler<GetMovieByIdQuery, Movie>
    {
        private readonly MoviesContext _persistenceContext;

        public GetMovieByIdQueryHandler(MoviesContext persistenceContext)
        {
            _persistenceContext = persistenceContext;
        }

        public Movie Handle(GetMovieByIdQuery query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query), "Parameter 'query' must not be null.");

            var movies = _persistenceContext
                .Movies
                .AsQueryable();

            if (query.FullGraph)
            {
                movies = movies
                    .Include(entity => entity.Genre)
                    .Include(entity => entity.MovieActors)
                    .ThenInclude(movieActor => movieActor.Actor);

            }

            var movie = movies
                .SingleOrDefault(entity => entity.Id == query.Id);

            _persistenceContext.Entry(movie).State = EntityState.Detached;
            
            return movie;
        }
    }
}
