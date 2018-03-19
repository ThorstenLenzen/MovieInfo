using System;
using System.Collections.Generic;
using System.Linq;
using Toto.MovieInfo.PersistenceModel;

namespace Toto.MovieInfo.DataAccess
{
    public class ListBasedActorRepository : IActorRepository
    {
        private readonly IList<Actor> _actors;

        public ListBasedActorRepository()
        {
            _actors = new List<Actor>
            {
                new Actor
                {
                    Key = "HarrsionFord1942",
                    FirstName = "Harrison",
                    LastName = "Ford",
                    BirthDate = new DateTime(1942, 12, 24),
                    Bio = "Lorem ipsum..."
                },
                new Actor
                {
                    Key = "JuliaOrmond1965",
                    FirstName = "Julia",
                    LastName = "Ormond",
                    BirthDate = new DateTime(1965, 01, 04),
                    Bio = "Lorem ipsum agein..."
                }
            };
        }

        public IList<Actor> GetAllActors()
        {
            return _actors;
        }

        public Actor GetActor(string actorKey)
        {
            return _actors.First(act => act.Key == actorKey);
        }

        public void UpdateActor(Actor actor)
        {
            var actorToRemove = _actors.First(act => act.Key == actor.Key);
            _actors.Remove(actorToRemove);
            _actors.Add(actor);
        }

        public void DeleteActor(string actorKey)
        {
            var actorToRemove = _actors.First(act => act.Key == actorKey);
            _actors.Remove(actorToRemove);
        }

        public void CreateActor(Actor actor)
        {
            _actors.Add(actor);
        }

        public bool ActorExist(string actorKey)
        {
            return _actors.Any(act => act.Key == actorKey);
        }

        public void Persist()
        { }
    }
}