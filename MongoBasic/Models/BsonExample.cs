using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoBasic.Models
{
    public class BsonExample
    {
        // Example of working directly with BSON documents instead of classes
        BsonDocument userStats = new BsonDocument {
        { "name" , "Jorge Rosas" },
        { "title" , "Mr." },
        { "amountOfBadges" , 360 }
      };
    }
}
