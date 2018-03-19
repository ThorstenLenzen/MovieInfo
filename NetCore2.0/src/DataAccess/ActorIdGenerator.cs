using System;
using System.Collections.Generic;
using System.Text;
using Toto.MovieInfo.PersistenceModel;

namespace Toto.MovieInfo.DataAccess
{
    public class actorKeyGenerator : IModelIdGenerator<Actor>
    {
        public string Create(Actor actor)
        {
            return actor.FirstName + actor.LastName + actor.BirthDate.Year;
        }
    }
}
