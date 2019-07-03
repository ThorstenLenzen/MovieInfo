using System.Collections.Generic;
using Toto.MovieInfo.MovieQueryService.Model;

namespace Toto.MovieInfo.MovieQueryService.Queries
{
    public class MovieOverviewQueryResult
    {
        public long Count { get; set; }
        public IList<MovieOverview> Movies { get; set; }
    }
}