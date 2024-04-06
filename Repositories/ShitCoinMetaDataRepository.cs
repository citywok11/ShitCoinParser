namespace ShitCoinParser.RepositoryModelFacade
{
    using Microsoft.Extensions.Options;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using ShitCoinParser.Configuration;
    using ShitCoinParser.Models;
    using ShitCoinParser.Repositories.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace Repositories
    {
        public class ShitCoinMetaDataRepository : IShitCoinMetaDataRepository
        {
            private readonly IMongoCollection<ShitCoinMetaData> _collection;
            private readonly ILogger<IShitCoinMetaDataRepository> _logger;

            public ShitCoinMetaDataRepository(IMongoClientFactory mongoClientFactory, ILogger<ShitCoinMetaDataRepository> logger, IOptions<MongoSettings> mongoSettings)
            {
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));

                // Use MongoSettings to get the collection name.
                var settings = mongoSettings.Value ?? throw new ArgumentNullException(nameof(mongoSettings));
                var collectionName = settings.MetaDataCollectionName ?? throw new ArgumentNullException("MetaDataCollectionName is not configured.");


                // Use the factory to get the collection directly.
                var database = mongoClientFactory.GetDatabase();
                _collection = database.GetCollection<ShitCoinMetaData>(collectionName);

                _logger.LogInformation("ShitCoinMetaDataRepository initialized successfully.");
            }

            public async Task<List<ShitCoinMetaData>> GetAllAsync()
            {
                return await _collection.Find(new BsonDocument()).ToListAsync();
            }
        }

    }
}