using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Toto.MovieInfo.DataAccess.EF;
using Toto.MovieInfo.PersistenceModel;

namespace DataAccess.Test
{
    public class DbTestHelper
    {
        public static MoviesContext Context
        {
            get
            {
                var connectionStringBuilder = new SqliteConnectionStringBuilder
                {
                    DataSource = ":memory:"
                };
                var connectionString = connectionStringBuilder.ToString();
                var connection = new SqliteConnection(connectionString);
                connection.Open();

                var options = new DbContextOptionsBuilder<MoviesContext>()
                    .UseSqlite(connection)
                    .Options;

                var context = new MoviesContext(options);
                context.Database.EnsureCreated();
                PopulateContext(context);

                return context;
            }
        }

        public static void PopulateContext(MoviesContext context)
        {
            var genre = new Genre
            {
                Id = Guid.NewGuid(),
                Name = "TestGenre",
                Description = "Test Genre Decsription"
            };

            var actor = new Actor
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "Actor"
            };

            var movie = new Movie
            {
                Id = Guid.NewGuid(),
                Description = "Test Movie Description",
                Name = "Test Movie",
                Genre = genre,
                ReleaseDate = "1111"
            };

            var movieActor = new MovieActor
            {
                Actor = actor,
                Movie = movie
            };

            movie.MovieActors.Add(movieActor);

            context.Movies.Add(movie);
            context.SaveChanges();
        }
    }
}
