using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public void AddActor(Actor actor)
        {
            _context.Actors.Add(actor);
        }

        public void SaveActor(Actor actor)
        {
            _context.Add(actor);
            _context.Entry(actor).State = EntityState.Modified;
        }

        public void DeleteActor(string key)
        {
            var actor = _context.Actors.Single(actr => actr.Key == key);
            _context.Actors.Remove(actor);
        }
    }
}
