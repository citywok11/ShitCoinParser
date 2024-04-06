using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ShitCoinParser.Models
{
    public class ShitCoinMetaData
    {
        [BsonId]
        public ObjectId _id { get; set; }

        [BsonElement("tokenName")]
        public string? tokenName { get; set; }

        [BsonElement("metaData")]
        public MetaData? metaData { get; set; }

        [BsonElement("liquidityLocked")]
        public bool liquidityLocked { get; set; }

        [BsonElement("tokenIsOnWebsiteOnLaunch")]
        public bool tokenIsOnWebsiteOnLaunch { get; set; }

        [BsonElement("hasFunctioningWebsite")]
        public bool hasFunctioningWebsite { get; set; }

        [BsonElement("hasRugged")]
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