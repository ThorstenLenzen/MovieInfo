using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toto.MovieInfo.DataAccess;
using Toto.MovieInfo.PersistenceModel;

namespace DataAccess.Test
{
    [TestClass]
    public class MongoBasedActorRepositoryTest
    {
        [TestMethod]
        public void CanGetAllActors()
        {
            var repo = new MongoBasedActorRepository();
            var actors = repo.GetAllActors();

            Assert.IsNotNull(actors);
        }

        [TestMethod]
        public void CanGetCrudAnActor()
        {
            var repo = new MongoBasedActorRepository();
            var actor = RyanGosling;
            var newBio = "Lorem ipsum...";

            repo.CreateActor(actor);
            var retrievedActor = repo.GetActor(actor.Key);

            Assert.AreEqual(actor.FirstName, retrievedActor.FirstName);

            actor.Bio = newBio;
            repo.UpdateActor(actor);
            retrievedActor = repo.GetActor(actor.Key);

            Assert.AreEqual(actor.Bio, retrievedActor.Bio);

            repo.DeleteActor(actor.Key);
            var exists = repo.ActorExist(actor.Key);

            Assert.IsFalse(exists);
        }

        private Actor RyanGosling => new Actor
        {
            Key       = "RyanGosling1980",
            FirstName = "Ryan",
            LastName  = "Gosling",
            BirthDate = new DateTime(1980),
            Bio       = "Canadian actor Ryan Gosling is the first person born in the 1980s to have been nominated for the Best Actor Oscar (for Half Nelson (2006)).",
        };
    }
}
