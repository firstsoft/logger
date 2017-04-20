using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;


using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Shared;
using MongoDB;
using MongoDB.Driver.Linq;
using MongoDB.Bson.IO;

using DTLib.mapped;

namespace DTLib.db
{
    internal class MongoDBProvider : IDbProvider
    {
        //mongodb://192.168.15.113:27017@Events
        public void Connect(string connectionstring)
        {
            //Register mapped registers
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();
            foreach(Type type in types)
            {
                if (type.GetInterface("IMappedRegister")!=null)
                {
                    IMappedRegister register = Activator.CreateInstance(type) as IMappedRegister;
                    register.Register();
                }
            }

            //connect db
            this.client = new MongoClient(connectionstring.Split('@')[0]);
            this.db = this.client.GetDatabase(connectionstring.Split('@')[1]);
        }


        public void Insert<T>(T obj, string table)
        {
            var collection = this.db.GetCollection<T>(table);
            collection.InsertOne(obj);
        }

        public void InsertMore<T>(List<T> objs, string table)
        {
            var collection = this.db.GetCollection<T>(table);
            collection.InsertMany(objs);
        }

        public void Update<T>(T obj, string table) {  }

        public IEnumerable<T> Query<T>(string table)
        {
            IMongoCollection<T> collection = db.GetCollection<T>(table);
            return collection.Aggregate().ToList();
        }

        public IEnumerable<T> Query<T>(string table, FilterDefinition<T> filter)
        {
            IMongoCollection<T> collection = db.GetCollection<T>(table);
            return collection.Find(filter).ToList();
        }

        private MongoClient client { get; set; }
        private IMongoDatabase db { get; set; }
    }
}
