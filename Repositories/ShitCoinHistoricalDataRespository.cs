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
        public class ShitCoinHistoricalDataRespository : IShitCoinHistoricalDataRepository
		{
            private readonly IMongoCollection<ShitCoinHistoricalDataModel> _collection;
            private readonly IConfiguration _configuration;

            public ShitCoinHistoricalDataRespository(MongoClientFactory mongoClientFactory, ILogger<ShitCoinMetaDataRepository> logger)
            {
                _configuration = _configuration ?? throw new ArgumentNullException(nameof(_configuration));

                var database = mongoClientFactory.GetDatabase();
                var collectionName = _configuration["MongoDB:HistoricalDataName"];

                _collection = database.GetCollection<ShitCoinHistoricalDataModel>(collectionName);

                logger.LogInformation("ShitCoinMetaDataRepository initialized successfully.");
            }

            public async Task<List<ShitCoinHistoricalDataModel>> GetAllAsync()
            {
                return await _collection.Find(new BsonDocument()).ToListAsync();
            }
        }

    }
}