using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Toto.MovieInfo.DataAccess.EF;
using Xunit;

namespace DataAccess.Test
{
    public class MoviesContextTests
    {
        [Fact]
        public void CanCreateMoviesContextToSqlServer()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var configuration = builder.Build();

            var connectionString = configuration["connectionStrings:movieContext"];

            var contextOptions = new DbContextOptionsBuilder<MoviesContext>()
                .UseSqlServer(connectionString)
                .Options;

            using (var ctx = new MoviesContext(contextOptions))
            {
                Assert.NotNull(ctx);
            } 
        }

        [Fact]
        public void CanWriteToContext()
        {
            using (var ctx = DbTestHelper.Context)
            {
                var count = ctx.Movies.Count();

                Assert.Equal(1, count);
            }
        }
    }
}
