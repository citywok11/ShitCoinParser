using System.ComponentModel.DataAnnotations;

namespace ShitCoinParser.Configuration
{
    public class MongoSettings : IMongoSettings
    {
        public string? ConnectionString { get; set; }
        public string? ShitCoinDbName { get; set; }
        public string? MetaDataCollectionName { get; set; }
        public string? HistoricalDataCollectionName { get; set; }
        public string? PriceAnalyticsCollectionName { get; set; }
    }
}