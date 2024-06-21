using MongoBasic.Models;
using MongoDB.Bson;
using MongoDB.Driver;

// A small practice exercise inspired by the MongoDB learning path with c#
string _Database = "<YOUR DATABASE>";
string serverConnection = "<YOUR CONNECTION STRING>";

var mongoURL = new MongoUrl(serverConnection);
var client = new MongoClient(mongoURL);

// insert
var database = client.GetDatabase(_Database);

var accountsCollection = database.GetCollection<Account>("account");

var accountsCollectionBson = database.GetCollection<BsonDocument>("account");

var documentBson = new BsonDocument
{
   { "account_id", "MDB829001110" },
   { "account_holder", "Linus Bson" },
   { "account_type", "checking" },
   { "balance", 11333477 }
};

var newAccount = new Account
{
    AccountId = "MDB829001337",
    AccountHolder = "Linus Torvalds",
    AccountType = "checking",
    Balance = 50352434
};

// insert with class
accountsCollection.InsertOne(newAccount);

// insert with bson
accountsCollectionBson.InsertOne(documentBson);

// async 
// await accountsCollection.InsertOneAsync(documentName);

// Insert Many with Class
var accountA = new Account
{
    AccountId = "MDB829001337",
    AccountHolder = "Linus Torvalds",
    AccountType = "checking",
    Balance = 50352434
};

var accountB = new Account
{
    AccountId = "MDB011235813",
    AccountHolder = "Ada Lovelace",
    AccountType = "checking",
    Balance = 60218
};

accountsCollection.InsertMany(new List<Account>() { accountA, accountB });

// Insert Many with bson document
var documents = new[]
{
    new BsonDocument
            {
                { "account_id", "MDB011235813" },
                { "account_holder", "Ada Lovelace" },
                { "account_type", "checking" },
                { "balance", 60218 }
            },
    new BsonDocument
            {
                { "account_id", "MDB829000001" },
                { "account_holder", "Muhammad ibn Musa al-Khwarizmi" },
                { "account_type", "savings" },
                { "balance", 267914296 }
            }
};

accountsCollectionBson.InsertMany(documents);

// async
// await accountsCollection.InsertManyAsync(new List<Account>() { accountA, accountB });

Console.WriteLine("Successfully inserted documents into the `accounts` collection!");