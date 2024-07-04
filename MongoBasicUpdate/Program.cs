using MongoBasic.Models;
using MongoDB.Driver;

string _Database = "<YOUR DATABASE>";
string serverConnection = "<YOUR CONNECTION STRING>";

var mongoURL = new MongoUrl(serverConnection);
var client = new MongoClient(mongoURL);

var database = client.GetDatabase(_Database);
var accountsCollection = database.GetCollection<Account>("account");

// Update operation
var filter = Builders<Account>.Filter.Eq(a => a.AccountId, "MDB829000001");
//var updateDefinition = Builders<Account>.Update.Set(a => a.Balance, 8000000m);
var updateDefinition = Builders<Account>.Update.Set("balance", 8000000m); // Directly set the decimal value
var updateResult = accountsCollection.UpdateOne(filter, updateDefinition);

Console.WriteLine($"Number of documents updated: {updateResult.ModifiedCount}");

var filterMany = Builders<Account>.Filter.Eq(a => a.AccountId, "MDB011235813");
//var updateDefinitionMany = Builders<Account>.Update.Set(a => a.Balance, 70000m);
var updateDefinitionMany = Builders<Account>.Update.Set("balance", 70000m); // Directly set the decimal value
var updateResultMany = accountsCollection.UpdateMany(filterMany, updateDefinitionMany);

Console.WriteLine($" Update Many - Number of documents updated: {updateResultMany.ModifiedCount}");