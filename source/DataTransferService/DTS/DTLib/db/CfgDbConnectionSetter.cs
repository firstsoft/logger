using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTLib.cfg;

namespace DTLib.db
{
    public class CfgDbConnectionSetter : ICfgSetter<string>
    {
        public CfgDbConnectionSetter()
        {
            DTEntry.Setters.Add(this.GetType(), this);
        }

        public void Set(Action<string> handler, string value)
        {
            this.Value = value;
            handler(value);
        }

        public void Set(string value)
        {
            this.Set((t) => {
                if (DTEntry.DbProvider == null)
                    DTEntry.DbProvider = new MongoDBProvider();
                DTLib.DTEntry.DbProvider.Connect(t);
            }, value);
        }

        public Action<string> Handler { get; private set; }
        public string Value { get; private set; }
    }
}
