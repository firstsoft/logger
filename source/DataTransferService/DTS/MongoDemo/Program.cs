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
using DTLib.log.collection;

namespace MongoDemo
{
    class Program
    {
        static void Main(string[] args)
        {
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

            var collection = DTLib.DTEntry.DbProvider.Query<Event>("Event");
            var filter = Builders<Event>.Filter.Eq(ev => ev.date, "2017-04-06");
            collection = DTLib.DTEntry.DbProvider.Query<Event>("Event", filter);
            Console.ReadLine();

            DTLib.DTEntry.looper.SendMsg(new DTLib.core.Message("exit"));
            Console.ReadLine();

        }
    }
}
