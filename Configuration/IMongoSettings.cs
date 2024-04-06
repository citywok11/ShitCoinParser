namespace ShitCoinParser.Configuration
{
    public interface IMongoSettings
    {
        public string ConnectionString { get; set; }
        public string? ShitCoinDbName { get; set; }
        public string? MetaDataCollectionName { get; set; }
        public string? HistoricalDataCollectionName { get; set; }
        public string? PriceAnalyticsCollectionName { get; set; }
    }
}
