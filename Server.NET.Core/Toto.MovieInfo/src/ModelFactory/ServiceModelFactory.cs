using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Toto.MovieInfo.PersistenceModel;
using Toto.MovieInfo.ServiceModel;

namespace Toto.MovieInfo.ModelFactory
{
    public class ServiceModelFactory : IServiceModelFactory
    {
        static ServiceModelFactory()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Movie, MovieOverview>();
            });
        }

        public ICollection<MovieOverview> CreateMovieOverviewCollection(ICollection<Movie> movies)
        {
            var movieOverviews = 
                Mapper.Map<ICollection<Movie>, ICollection<MovieOverview>>(movies);

            return movieOverviews;
        }
    }
}
