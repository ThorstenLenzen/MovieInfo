using System.Collections.Generic;
using MongoDB.Bson;

namespace Toto.MovieInfo.MovieQueryService.Model
{
    public class MovieOverview
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
    }
}
