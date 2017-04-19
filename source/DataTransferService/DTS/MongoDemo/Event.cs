using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Driver;
using MongoDB.Bson;

using MongoDB.Driver.Core;
using MongoDB.Bson.Serialization.Attributes;
namespace MongoDemo
{
    [BsonIgnoreExtraElements]
    public class Event
    {
        [BsonId]
        public ObjectId guid { get; set; }

        public string id { get; set; }
        public string name { get; set; }
        public int count { get; set; }
    }
}
