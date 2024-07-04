
using MongoBasic.Models;
using MongoDB.Driver;

string _Database = "<YOUR DATABASE>";
string serverConnection = "<YOUR CONNECTION STRING>";

var mongoURL = new MongoUrl(serverConnection);
var client = new MongoClient(mongoURL);

var database = client.GetDatabase(_Database);
var accountsCollection = database.GetCollection<Account>("account");

var accountsToInsert = new List<Account>
        {
            new Account
            {
                AccountId = "MDB123456789",
                AccountHolder = "John Doe",
                AccountType = "checking",
                Balance = 10000
            },
            new Account
            {
                AccountId = "MDB987654321",
                AccountHolder = "Jane Smith",
                AccountType = "savings",
                Balance = 50000
            },
            new Account
            {
                AccountId = "MDB246813579",
                AccountHolder = "Bob Johnson",
                AccountType = "checking",
                Balance = 25000
            },
           new Account
            {
                AccountId = "MDB24681357911",
                AccountHolder = "MiguelSegura",
                AccountType = "checking",
                Balance = 25000
            }
        };

await accountsCollection.InsertManyAsync(accountsToInsert);

Console.WriteLine("Successfully inserted documents into the `accounts` collection!");

// Delete One document
var filterDeleteOne = Builders<Account>.Filter.Eq(a => a.AccountId, "MDB123456789");
var deleteResultOne = await accountsCollection.DeleteOneAsync(filterDeleteOne);
Console.WriteLine($"Deleted {deleteResultOne.DeletedCount} document.");

// Delete Many documents by AccountId
var accountIdsToDelete = new List<string> { "MDB987654321", "MDB246813579" };
var filterDeleteMany = Builders<Account>.Filter.In(a => a.AccountId, accountIdsToDelete);
var deleteResultMany = await accountsCollection.DeleteManyAsync(filterDeleteMany);
Console.WriteLine($"Deleted {deleteResultMany.DeletedCount} documents.");