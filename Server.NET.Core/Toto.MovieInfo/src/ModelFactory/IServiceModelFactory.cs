using System.Collections.Generic;
using Toto.MovieInfo.PersistenceModel;
using Toto.MovieInfo.ServiceModel;

namespace Toto.MovieInfo.ModelFactory
{
    public interface IServiceModelFactory
    {
        ICollection<MovieOverview> CreateMovieOverviewCollection(ICollection<Movie> movies);
    }
}