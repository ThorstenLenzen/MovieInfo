using MongoDB.Driver;

namespace Toto.DataAccess.Mongo
{
    public interface IPersistenceContext
    {
        IMongoCollection<TCollection> GetCollection<TCollection>(string entityName);
    }
}
