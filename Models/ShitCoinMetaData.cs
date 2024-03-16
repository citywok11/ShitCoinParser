using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ShitCoinParser.Models
{
    public class ShitCoinMetaData
    {
        public MetaDataId? _id { get; set; }
        public string? tokenName { get; set; }
        public MetaData? metaData { get; set; }
        public bool liquidityLocked { get; set; }
        public bool tokenIsOnWebsiteOnLaunch { get; set; }
        public bool hasFunctioningWebsite { get; set; }
        public bool hasRugged { get; set; }
    }

    public class Creator
    {
        public string? name { get; set; }
        public string? site { get; set; }
    }

    public class MetaDataId
    {
        [BsonId] 
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
    }

    public class MetaData
    {
        public string? name { get; set; }
        public string? symbol { get; set; }
        public string? mintId { get; set; }
        public string? twitter { get; set; }
        public string? telegram { get; set; }
        public string? website { get; set; }
        public DateTime poolOpened { get; set; }
        public Creator? creator { get; set; }
    }
}