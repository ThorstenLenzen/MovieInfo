using System.Collections.Generic;
using PersistenceModel.SqlServer;

namespace Toto.MovieInfo.DataAccess.Contracts.SqlServer
{
    public interface IActorRepository
    {
        IEnumerable<Actor> GetActors();
        IEnumerable<Actor> GetActors(int skip, int take);
        Actor GetActor(string key);
    }
}