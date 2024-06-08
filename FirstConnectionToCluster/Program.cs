using MongoDB.Driver;

// A small practice exercise inspired by the MongoDB learning path
var mongoURL = new MongoUrl("<your connection string>");
var client = new MongoClient(mongoURL);

var dbList = client.ListDatabases().ToList();

Console.WriteLine("The list of databases on this server is: ");

Array.ForEach(dbList.ToArray(), db =>
{
    var dbName = db["name"].AsString;
    Console.WriteLine($"Database: {dbName}");

    var database = client.GetDatabase(dbName);

    Console.WriteLine("The list of collections on this database is: ");

    var collections = database.ListCollectionNames().ToList();

    Array.ForEach(collections.ToArray(), collectionName =>
    {
        Console.WriteLine($"\tCollection: {collectionName}");
    });
});