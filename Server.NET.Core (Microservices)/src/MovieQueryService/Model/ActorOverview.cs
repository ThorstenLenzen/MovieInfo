using MongoDB.Bson;

namespace Toto.MovieInfo.MovieQueryService.Model
{
    public class ActorOverview
    {
        public ObjectId Id { get; set; }
        public string FullName { get; set; }
    }
}
