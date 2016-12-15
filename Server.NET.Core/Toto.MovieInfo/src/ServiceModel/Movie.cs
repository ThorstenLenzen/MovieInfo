using System;
using System.Collections.Generic;

namespace Toto.MovieInfo.ServiceModel
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ReleaseDate { get; set; }
        public IList<Performer> Performers { get; set; }
    }
}
