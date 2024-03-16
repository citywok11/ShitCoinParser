using MongoDB.Driver;

public interface IMongoClientFactory
{
    IMongoDatabase GetDatabase();
    IMongoCollection<TDocument> GetCollection<TDocument>(string collectionName);
}