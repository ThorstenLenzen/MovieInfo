using MongoDB.Bson;

namespace Toto.MovieInfo.MovieQueryService.Model
{
    public class Genre
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
    }
}
