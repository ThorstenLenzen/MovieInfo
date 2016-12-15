using System;
using System.Collections.Generic;

namespace Toto.MovieInfo.ServiceModel
{
    public class Performer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public IList<Movie> Movies { get; set; }
    }
}