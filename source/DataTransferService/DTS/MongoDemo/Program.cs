using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Shared;
using MongoDB;
using MongoDB.Driver.Linq;
using MongoDB.Bson.IO;

using DTLib.db;
using DTLib.log;

namespace MongoDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            

            //1
            //var client = new MongoClient("mongodb://192.168.15.113:27017");

            //var db = client.GetDatabase("Events");
            //BsonClassMap.RegisterClassMap<Event>();

            //IMongoCollection<Event> collection = db.GetCollection<Event>("Event");
            ////var document = new BsonDocument { { "id", "001" }, { "name", "yashan" } };
            ////collection.InsertOne(document);

            //// collection.InsertOne(new Event() { id = "002", name = "testing" });
            //var document = BsonDocument.Parse("{id: \"008\" , name :\"testing003\", count: 1}");
            //db.GetCollection<BsonDocument>("Event").InsertOne(document);

            //var builder = Builders<Event>.Filter.Eq(eve => eve.id, "001");
            //var result = collection.Find(builder).ToList();
            //var events = result.ToList();
            //var result1 = collection.Aggregate().ToList();

            //2
            //var str = "{a:100}";
            //var bsonreader = new JsonReader(str);
            //bsonreader.ReadStartDocument();
            //Console.WriteLine(bsonreader.ReadName());
            //Console.WriteLine(bsonreader.ReadInt32());
            //bsonreader.ReadEndDocument();

            //Console.ReadLine();

            TaskScheduler scheduler = TaskScheduler.Current;
            
            //3
            //Task t = Task.Run(() =>
            //{
            //    System.Threading.Thread.Sleep(2000);
            //    Console.WriteLine("testing");

            //});
            
            ////TaskScheduler.Current.
            //t.Wait();
            //Console.WriteLine(t.Id);

            //Task t2 = new System.Threading.Tasks.Task(() =>
            //{
            //    System.Threading.Thread.Sleep(2000);
            //    Console.WriteLine("do");
            //});
            //t2.Start();
            //t2.Wait();
            //Console.WriteLine(t2.Id);

            //4

            //MongoDBProvider provider = new MongoDBProvider();
            //provider.init();
            DTLib.DTEntry.Run();


            DTLib.DTEntry.looper.SendMsg(new DTLib.core.Message("set connection", () =>
            {
                if (!DTLib.DTEntry.Setters.ContainsKey(typeof(CfgDbConnectionSetter)))
                {
                    CfgDbConnectionSetter cfgProvider = new CfgDbConnectionSetter();
                    cfgProvider.Set("mongodb://192.168.15.113:27017@Events");
                    Console.WriteLine("set connection string");
                }
            }));
            Console.ReadLine();

            DTLib.DTEntry.looper.SendMsg(new DTLib.core.Message("set cfg path", () => {
                if (!DTLib.DTEntry.Setters.ContainsKey(typeof(CfgLogPathSetter)))
                {
                    CfgLogPathSetter cfgPathRegister = new CfgLogPathSetter();
                    cfgPathRegister.Set(@"E:\Work\yashanyang_view10\Casino\AH\Data\Log");
                    Console.WriteLine("set log path");
                }
            }));
            Console.ReadLine();


            DTLib.DTEntry.looper.SendMsg(new DTLib.core.Message("exit"));
            Console.ReadLine();


        }
    }
}
