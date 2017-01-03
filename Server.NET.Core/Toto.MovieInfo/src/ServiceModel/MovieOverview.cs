using System;

namespace Toto.MovieInfo.ServiceModel
{
    public class MovieOverview
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ReleaseDate { get; set; }
    }
}
