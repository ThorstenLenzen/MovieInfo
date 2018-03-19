using System.Collections.Generic;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Toto.MovieInfo.PersistenceModel;

namespace Toto.MovieInfo.DataAccess
{
    public class MongoBasedActorRepository : IActorRepository
    {
        private readonly IMongoCollection<Actor> _actorsCollection;

        static MongoBasedActorRepository()
        {
            BsonClassMap.RegisterClassMap<Actor>(map =>
            {
                map.AutoMap();
                map.MapIdMember(cl => cl.Key);
            });
        }

        public MongoBasedActorRepository()
        {
            var client = new MongoClient("mongodb://127.0.0.1");
            var database = client.GetDatabase("movieinfo");

            _actorsCollection = database.GetCollection<Actor>("actors");
        }

        public void CreateActor(Actor actor)
        {
            _actorsCollection
                .InsertOne(actor);
        }

        public void DeleteActor(string actorKey)
        {
            _actorsCollection
                .DeleteOne(act => act.Key == actorKey);
        }

        public Actor GetActor(string actorKey)
        {
            return _actorsCollection
                .Find(act => act.Key == actorKey)
                .SingleOrDefault();
        }

        public IList<Actor> GetAllActors()
        {
            return _actorsCollection
                .Find(act => true)
                .ToList();
        }

        public void Persist()
        {
            // No Implementation in this specific use case with mongo.
        }

        public void UpdateActor(Actor actor)
        {
            _actorsCollection
                .ReplaceOne(act => act.Key == actor.Key, actor);
        }

        public bool ActorExist(string actorKey)
        {
            return _actorsCollection.Count(act => act.Key == actorKey) > 0;
        }
    }
}
