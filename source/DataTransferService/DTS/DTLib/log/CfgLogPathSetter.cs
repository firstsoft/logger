using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTLib.cfg;
using DTLib.core;
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
                Console.WriteLine("Constructing");
                return;
                //string[] files = Directory.GetFiles(value, "ASLog*.log");
                //foreach(string file in files)
                //{
                //    DTEntry.looper.SendMsg(new Message("import log", () => Actions.Import(file)) { WorkMode = WorkMode.TaskScheduler });
                //}
            }, value);
        }

        public Action<string> Handler { get; private set; }
        public string Value { get; private set; }
    }
}
