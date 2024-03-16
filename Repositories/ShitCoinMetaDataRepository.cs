namespace ShitCoinParser.RepositoryModelFacade
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using ShitCoinParser.Models;
    using ShitCoinParser.Repositories.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace Repositories
    {
        public class ShitCoinMetaDataRepository : IShitCoinMetaDataRepository
        {
            private readonly IMongoCollection<ShitCoinMetaData> _collection;
            private readonly IConfiguration _configuration;
            private readonly ILogger<IShitCoinMetaDataRepository> _logger;

            public ShitCoinMetaDataRepository(MongoClientFactory mongoClientFactory, ILogger<ShitCoinMetaDataRepository> logger, IConfiguration configuration)
            {
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
                _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration)); 

                var database = mongoClientFactory.GetDatabase();
                var collectionName = _configuration["MongoDB:MetaDataName"];
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