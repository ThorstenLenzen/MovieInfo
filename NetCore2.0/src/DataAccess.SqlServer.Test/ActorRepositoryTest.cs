using System;
using System.Linq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using PersistenceModel.SqlServer;
using Toto.MovieInfo.DataAccess.SqlServer;
using Xunit;

namespace DataAccess.SqlServer.Test
{
    public class ActorRepositoryTest
    {

        private readonly DbContextOptions<MovieInfoContext> _options;

        public ActorRepositoryTest()
        {
            //Here create the options using SQLite CreateOptions
            _options = SQLiteInMemory.CreateContextOptions<MovieInfoContext>();
        }

        [Fact]
        public void GetActorsReturnsAllActors()
        {
            using (var context = new MovieInfoContext(_options))
            {
                context.Database.EnsureCreated();
                context.SeedDefaultActors();

                var repository = new ActorRepository(context);
                var allActors = repository.GetActors();

                allActors.Count().Should().Be(3);
            }
        }

        [Fact]
        public void GetActorsWithSkipTakeReturnsCorrectActors()
        {
            using (var context = new MovieInfoContext(_options))
            {
                context.Database.EnsureCreated();
                context.SeedDefaultActors();

                var repository = new ActorRepository(context);
                var actors = repository.GetActors(2, 1);

                actors.Count().Should().Be(1);
            }
        }

        [Fact]
        public void GetActorWithKeyCorrectActor()
        {
            using (var context = new MovieInfoContext(_options))
            {
                context.Database.EnsureCreated();
                context.SeedDefaultActors();
                var key = context.Actors.First().Key;

                var repository = new ActorRepository(context);
                var actor = repository.GetActor(key);

                actor.LastName.Should().Be("Ford");
            }
        }

        [Fact]
        public void AddActorSucceeds()
        {
            using (var context = new MovieInfoContext(_options))
            {
                context.Database.EnsureCreated();

                var actor = new Actor
                {
                    Id = Guid.NewGuid(),
                    Key = "harrisonford",
                    FirstName = "Harrison",
                    LastName = "Ford",
                    Bio = "Lorem ipsum..."
                };

                var repository = new ActorRepository(context);
                repository.AddActor(actor);
                context.SaveChanges();

                context.Actors.Any(actr => actr.Key == actor.Key).Should().BeTrue();
            }
        }

        [Fact]
        public void UpdateActorSucceeds()
        {
            using (var context = new MovieInfoContext(_options))
            {
                context.Database.EnsureCreated();
                context.SeedDefaultActors();
                var actor = context.Actors.Single(actr => actr.Key == "harrisonford");
                actor.Bio = "New Lorem Ipsum...";

                var repository = new ActorRepository(context);
                repository.SaveActor(actor);
                context.SaveChanges();

                context.Actors.Any(actr => actr.Bio == actor.Bio).Should().BeTrue();
            }
        }

        [Fact]
        public void UpdateActorDisconectedSucceeds()
        {
            Actor actor;
            using (var context = new MovieInfoContext(_options))
            {
                context.Database.EnsureCreated();
                context.SeedDefaultActors();
                actor = context.Actors.Single(actr => actr.Key == "harrisonford");
            }

            actor.Bio = "New Lorem Ipsum...";

            using (var context = new MovieInfoContext(_options))
            {
                context.Database.EnsureCreated();
                context.SeedDefaultActors();

                var repository = new ActorRepository(context);
                repository.SaveActor(actor);
                context.SaveChanges();

                context.Actors.Any(actr => actr.Bio == actor.Bio).Should().BeTrue();
            }
        }

        [Fact]
        public void DeleteActorSucceeds()
        {
            using (var context = new MovieInfoContext(_options))
            {
                context.Database.EnsureCreated();
                context.SeedDefaultActors();
                var actor = context.Actors.Single(actr => actr.Key == "harrisonford");

                var repository = new ActorRepository(context);
                repository.DeleteActor(actor.Key);
                context.SaveChanges();

                context.Actors.Any(actr => actr.Key == actor.Key).Should().BeFalse();
            }
        }
    }
}
