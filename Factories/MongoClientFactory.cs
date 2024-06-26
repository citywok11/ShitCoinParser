﻿using MongoDB.Driver;
using Microsoft.Extensions.Options;
using ShitCoinParser.Configuration;
using ShitCoinParser.Services;
using ShitCoinParser.Services.Interfaces;

public class MongoClientFactory : IMongoClientFactory
{
    private readonly IMongoSettings _mongoSettings;
    private readonly ILogger<MongoClientFactory> _logger;
    private readonly IOptions<IMongoSettings> _settings;

    public MongoClientFactory(IOptions<IMongoSettings> settings, ILogger<MongoClientFactory> logger)
    {
        _mongoSettings = settings.Value;
        _logger = logger;
    }

    public IMongoDatabase GetDatabase()
    {
        try
        {
            var client = new MongoClient(_mongoSettings.ConnectionString);
            var database = client.GetDatabase(_mongoSettings.ShitCoinDbName);
            _logger.LogInformation($"Accessed MongoDB database: {_mongoSettings.ShitCoinDbName}");
            return database;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Failed to access MongoDB database: {_mongoSettings.ShitCoinDbName}");
            throw; // Re-throw the exception to ensure the calling code can handle it or fail accordingly.
        }
    }

    public IMongoCollection<TDocument> GetCollection<TDocument>(string collectionName)
    {
        try
        {
            var database = GetDatabase();
            var collection = database.GetCollection<TDocument>(collectionName);
            _logger.LogInformation($"Accessed MongoDB collection: {collectionName}");
            return collection;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Failed to access MongoDB collection: {collectionName}");
            throw; // Similar to above, re-throw to allow for external handling.
        }
    }
}
