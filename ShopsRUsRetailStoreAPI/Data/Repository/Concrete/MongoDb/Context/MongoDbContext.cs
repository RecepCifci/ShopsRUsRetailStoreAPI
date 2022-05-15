using ShopsRUsRetailStoreAPI.Data.Repository.Abstract;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using ShopsRUsRetailStoreAPI.Data.Entity;

namespace ShopsRUsRetailStoreAPI.Data.Repository.Concrete.MongoDb.Context
{
    public class MongoDbContext : IContext
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;
        public MongoDbContext(IOptions<DbSettings> dbOptions)
        {
            var settings = dbOptions.Value;
            _client = new MongoClient(settings.ConnectionString);
            _database = _client.GetDatabase(settings.DatabaseName);

            Products = _database.GetCollection<Product>(settings.ProductCollectionName);
            Customers = _database.GetCollection<Customer>(settings.CustomerCollectionName);
        }

        public IMongoClient Client => _client;
        public IMongoDatabase Database => _database;
        public IMongoCollection<Product> Products { get; }
        public IMongoCollection<Customer> Customers { get; }
    }
}
