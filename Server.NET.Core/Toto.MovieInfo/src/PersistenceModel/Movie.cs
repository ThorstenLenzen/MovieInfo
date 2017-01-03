using System;
using System.Collections.Generic;

namespace Toto.MovieInfo.PersistenceModel
{
    public class Movie
    {
        public Guid Id { get; set; }
        public Guid? GenreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ReleaseDate { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
    }
}
