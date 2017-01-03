using System.Collections.Generic;
using Toto.MovieInfo.PersistenceModel;

namespace Toto.MovieInfo.DataAccess
{
    public class GetMoviesQuery : IQuery<ICollection<Movie>>
    {
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
        public bool FullGraph { get; set; } = false;
    }
}
