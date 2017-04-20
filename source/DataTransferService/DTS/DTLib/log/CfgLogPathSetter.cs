using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Driver;

using DTLib.cfg;
using DTLib.core;
using DTLib.log.collection;
namespace DTLib.log
{
    public class CfgLogPathSetter : ICfgSetter<string>
    {
        public CfgLogPathSetter()
        {
            DTEntry.Setters.Add(this.GetType(), this);
        }

        public void Set(Action<string> handler,string value)
        {
            handler(value);
            this.Value = value;
        }

        public void Set(string value) {
            this.Set((t) =>
            {
                string[] files = Directory.GetFiles(value, "ASLog*.log");
                foreach (string file in files)
                {
                    FilterDefinition<collection.Task> filter = Builders<collection.Task>.Filter.Eq(task => task.file, file);
                    if (DTEntry.DbProvider.Query<collection.Task>("Task", filter).Count() <= 0)
                    {
                        DTEntry.DbProvider.Insert<collection.Task>(new collection.Task()
                        {
                            file = file,
                            status =0,
                            
                        }, "Task");
                        DTEntry.looper.SendMsg(new Message("import log", () => Actions.Import(file)) { WorkMode = WorkMode.TaskScheduler });
                    }
                }
            }, value);
        }

        public Action<string> Handler { get; private set; }
        public string Value { get; private set; }
    }
}
