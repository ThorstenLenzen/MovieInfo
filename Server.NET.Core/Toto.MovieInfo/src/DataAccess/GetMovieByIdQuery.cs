using System;
using Toto.MovieInfo.PersistenceModel;

namespace Toto.MovieInfo.DataAccess
{
    public class GetMovieByIdQuery : IQuery<Movie>
    {
        public Guid Id { get; set; }
        public bool FullGraph { get; set; } = true;
    }
}
