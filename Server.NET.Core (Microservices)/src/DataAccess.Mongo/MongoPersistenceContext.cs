using MongoDB.Driver;

namespace Toto.DataAccess.Mongo
{
    public class MongoPersistenceContext : IPersistenceContext
    {
        private readonly IMongoDatabase _database;

        public MongoPersistenceContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<TCollection> GetCollection<TCollection>(string entityName)
        {
            return _database.GetCollection<TCollection>(entityName);
        }
    }
}
