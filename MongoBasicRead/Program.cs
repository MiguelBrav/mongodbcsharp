
using MongoBasic.Models;
using MongoDB.Bson;
using MongoDB.Driver;


string _Database = "<YOUR DATABASE>";
string serverConnection = "<YOUR CONNECTION STRING>";

var mongoURL = new MongoUrl(serverConnection);
var client = new MongoClient(mongoURL);

var database = client.GetDatabase(_Database);
var accountsCollection = database.GetCollection<Account>("account");

var filter = Builders<Account>.Filter.Eq(a => a.AccountHolder, "Linus Torvalds");
var foundAccount = accountsCollection.Find(filter).FirstOrDefault();

if (foundAccount != null)
{
    Console.WriteLine($"Found account:");
    Console.WriteLine($"Id: {foundAccount.Id}");
    Console.WriteLine($"Account Id: {foundAccount.AccountId}");
    Console.WriteLine($"Account Holder: {foundAccount.AccountHolder}");
    Console.WriteLine($"Account Type: {foundAccount.AccountType}");
    Console.WriteLine($"Balance: {foundAccount.Balance}");
}
else
{
    Console.WriteLine("No account found for the specified account holder.");
}
