namespace ShitCoinParser.RepositoryModelFacade
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using ShitCoinParser.Configuration;
    using ShitCoinParser.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace Repositories
    {
        public class ShitCoinMetaDataRepository
        {
            private readonly IMongoCollection<ShitCoinMetaData> _collection;

            // Constructor now accepts MongoClientFactory and ILogger (if needed for logging within the repository)
            public ShitCoinMetaDataRepository(MongoClientFactory mongoClientFactory, ILogger<ShitCoinMetaDataRepository> logger)
            {
                var database = mongoClientFactory.GetDatabase();

                _collection = database.GetCollection<ShitCoinMetaData>("ShitCoinMetaData");

                logger.LogInformation("ShitCoinMetaDataRepository initialized successfully.");
            }

            public async Task<List<ShitCoinMetaData>> GetAllAsync()
            {
                return await _collection.Find(new BsonDocument()).ToListAsync();
            }
        }

    }
}