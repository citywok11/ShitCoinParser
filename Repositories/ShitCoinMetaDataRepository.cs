﻿namespace ShitCoinParser.RepositoryModelFacade
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
                try
                {
                    return await _collection.Find(new BsonDocument()).ToListAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError($"An error occurred while fetching data: {ex.Message}");
                    // Depending on your error handling strategy, you might want to rethrow, return null, or an empty list
                    return new List<ShitCoinMetaData>();
                }
            }

            public async Task<IEnumerable<string>> GetAllIdsAsync()
            {
                try
                {
                    // Project the result to only include the _id field
                    var projection = Builders<ShitCoinMetaData>.Projection.Include(x => x._id);
                    var documents = await _collection.Find(new BsonDocument())
                                                     .Project<BsonDocument>(projection)
                                                     .ToListAsync();

                    // Convert the BsonDocument list to a list of string representations of _id
                    var idList = documents.Select(doc => doc["_id"].ToString()).ToList();
                    return idList;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"An error occurred while fetching _id values: {ex.Message}");
                    return new List<string>(); // Return an empty list in case of an error
                }
            }
        }

    }
}