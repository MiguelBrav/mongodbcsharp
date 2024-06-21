using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace MongoBasic.Models;

public class Account
{
    // example of class to work with mongo db
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("account_id")]
    public string AccountId { get; set; }

    [BsonElement("account_holder")]
    public string AccountHolder { get; set; }

    [BsonElement("account_type")]
    public string AccountType { get; set; }

    [BsonRepresentation(BsonType.Decimal128)]
    [BsonElement("balance")]
    public decimal Balance { get; set; }

    [BsonElement("transfers_complete")]
    public string[] TransfersCompleted { get; set; }
}
