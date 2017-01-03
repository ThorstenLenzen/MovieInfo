using Microsoft.EntityFrameworkCore;
using Toto.MovieInfo.PersistenceModel;
using Toto.MovieInfo.DataAccess.EF.Mapping;
using Toto.MovieInfo.DataAccess.EF.Helper;

namespace Toto.MovieInfo.DataAccess.EF
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions options)
            : base(options)
        { /* EMPTY! */ }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Performers { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AddConfiguration(new MovieMap());
            modelBuilder.AddConfiguration(new GenreMap());
            modelBuilder.AddConfiguration(new ActorMap());
            modelBuilder.AddConfiguration(new MovieActorMap());
        }
    }
}
