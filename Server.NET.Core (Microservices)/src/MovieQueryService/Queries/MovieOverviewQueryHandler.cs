using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Toto.DataAccess.Mongo;
using Toto.MovieInfo.MovieQueryService.Model;

namespace Toto.MovieInfo.MovieQueryService.Queries
{
    public class MovieOverviewQueryHandler : IMovieOverviewQueryHandler
    {
        private readonly IMongoCollection<MovieOverview> _collection;

        public MovieOverviewQueryHandler(IPersistenceContext context)
        {
            _collection = context.GetCollection<MovieOverview>("movies");
        }

        public MovieOverviewQueryResult Handle(MovieOverviewsQuery query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query), "Parameter 'query' must not be null.");

            var count = _collection.Find(mov => true).Count();

            if (query.Skip >= count)
                throw new ArgumentOutOfRangeException(
                    nameof(query.Skip), 
                    query.Skip,
                    $"Skip ({query.Skip}) is greater or eqaul as the number of movies in store ({count}).");


            IList<MovieOverview> movies = _collection
                .Find(mov => true)
                .SortBy(mov => mov.Name)
                .Skip(query.Skip)
                .Limit(query.Take)
                .ToList();

            return new MovieOverviewQueryResult()
            {
                Count = count,
                Movies = movies
            };
        }
    }
}
