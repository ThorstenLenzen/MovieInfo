using System.Collections.Generic;
using Toto.CQRS;
using Toto.MovieInfo.MovieQueryService.Model;

namespace Toto.MovieInfo.MovieQueryService.Queries
{
    public class MovieOverviewsQuery : IQuery<MovieOverviewQueryResult>
    {
        public int Skip { get; set; }   
        public int Take { get; set; }
    }
}
