using System.Collections.Generic;
using Toto.MovieInfo.PersistenceModel;

namespace Toto.MovieInfo.DataAccess
{
    public interface IActorRepository
    {
        void CreateActor(Actor actor);
        void DeleteActor(string actorKey);
        Actor GetActor(string actorKey);
        IList<Actor> GetAllActors();
        void Persist();
        void UpdateActor(Actor actor);

        bool ActorExist(string actorKey);
    }
}