using System;

namespace Toto.MovieInfo.PersistenceModel
{
    public class MovieActor
    {
        public Guid MovieId { get; set; }
        public Guid ActorId { get; set; }
        public bool IsMainCast { get; set; }
        public virtual Actor Actor { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
