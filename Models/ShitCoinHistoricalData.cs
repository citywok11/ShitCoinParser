using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace ShitCoinParser.Models
{
    public class HistoricalData
    {
        public List<Price0>? Price_0 { get; set; }
        public Dictionary<string, List<PricePoint>> AdditionalPrices { get; set; }

        public HistoricalData()
        {
            AdditionalPrices = new Dictionary<string, List<PricePoint>>() ?? [];
        }
    }

    public class PricePoint
    {
        public double AmountOfSolInPool { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class Price0
    {
        // Assuming Price0 has a different structure than PricePoint, otherwise you can remove this class
        // and use PricePoint directly in the List for Price_0.
        public double AmountOfSolInPool { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class ShitCoinHistoricalDataModel
    {
        [JsonProperty("$oid")]
        public string? oid { get; set; }
    }

    public class Root
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Id? _id { get; set; }
        public string? ShitCoinId { get; set; }
        public List<object>? HistoricalData { get; set; }
    }

}