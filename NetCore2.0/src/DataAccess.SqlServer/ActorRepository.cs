using System.Collections.Generic;
using System.Linq;
using PersistenceModel.SqlServer;
using Toto.MovieInfo.DataAccess.Contracts;

namespace Toto.MovieInfo.DataAccess.SqlServer
{
    public class ActorRepository : IActorRepository
    {
        private readonly MovieInfoContext _context;

        public ActorRepository(MovieInfoContext context)
        {
            _context = context;
        }

        public IEnumerable<Actor> GetActors()
        {
            return _context.Actors;
        }

        public IEnumerable<Actor> GetActors(int skip, int take)
        {
            return _context.Actors.Skip(skip).Take(take);
        }

        public Actor GetActor(string key)
        {
            return _context.Actors.FirstOrDefault(actor => actor.Key == key);
        }
    }
}
