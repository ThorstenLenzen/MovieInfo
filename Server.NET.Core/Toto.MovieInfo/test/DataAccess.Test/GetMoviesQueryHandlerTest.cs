using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toto.MovieInfo.DataAccess;
using Toto.MovieInfo.DataAccess.EF;
using Toto.MovieInfo.PersistenceModel;
using Toto.Utilities.Extensions;
using Xunit;

namespace DataAccess.Test
{
    public class GetMoviesQueryHandlerTest
    {
        private class QueryHandlerBuilder
        {
            private MoviesContext _context;

            public QueryHandlerBuilder()
            {
                _context = DbTestHelper.Context;
            }

            public QueryHandlerBuilder WithMoviesContext(MoviesContext context)
            {
                _context = context;
                return this;
            }

            public GetMoviesQueryHandler Build()
            {
                return new GetMoviesQueryHandler(_context);
            }
        }

        [Fact]
        public void GetMoviesQueryHandler_WithNullQuery_ThrowsArgumentNullException()
        {
            //Arrange
            var handler = new QueryHandlerBuilder().Build();

            //Act
            var exception = Record.Exception(() => handler.Handle(null));

            //Assert
            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public void GetMoviesQueryHandler_WithDefaultParameters_ReturnsNonEmptyMovieCollection()
        {
            //Arrange
            var handler = new QueryHandlerBuilder().Build();
            var query = new GetMoviesQuery();

            //Act
            var movies = handler.Handle(query);

            //Assert
            Assert.NotEmpty(movies);
        }

        [Fact]
        public void GetMoviesQueryHandler_WithDefaultParameters_ReturnsMoviesWithoutChildren()
        {
            //Arrange
            var handler = new QueryHandlerBuilder().Build();
            var query = new GetMoviesQuery();

            //Act
            var movie = handler.Handle(query).First();

            //Assert
            Assert.Null(movie.Genre);
            Assert.Empty(movie.MovieActors);
        }

        [Fact]
        public void GetMoviesQueryHandler_WithFullGraphTrue_ReturnsMoviesWithChildren()
        {
            //Arrange
            var handler = new QueryHandlerBuilder().Build();
            var query = new GetMoviesQuery
            {
                FullGraph = true
            };

            //Act
            var movie = handler.Handle(query).First();

            //Assert
            Assert.NotNull(movie.Genre);
            Assert.NotEmpty(movie.MovieActors);
            movie.MovieActors.ForEach(Assert.NotNull);
        }
    }
}
