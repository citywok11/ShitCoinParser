using System.ComponentModel.DataAnnotations;

namespace ShitCoinParser.Configuration
{
    public class MongoSettings : IMongoSettings
    {
        [Required]
        public string? ConnectionString { get; set; }
        [Required]
        public string? ShitDatabaseName { get; set; }
        [Required]
        public string? HistoricalDataName { get; set; }
        [Required]
        public string? MetaDataName { get; set; }
    }
}