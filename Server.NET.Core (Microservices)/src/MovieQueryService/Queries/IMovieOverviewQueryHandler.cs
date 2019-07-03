using Toto.CQRS;

namespace Toto.MovieInfo.MovieQueryService.Queries
{
    public interface IMovieOverviewQueryHandler : IQueryHandler<MovieOverviewsQuery, MovieOverviewQueryResult>
    {}
}