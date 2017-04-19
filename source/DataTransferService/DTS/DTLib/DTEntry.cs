using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;


using DTLib.cfg;
using DTLib.core;
using DTLib.db;

namespace DTLib
{
    public class DTEntry
    {

        public static void Run()
        {
            Setters = new Dictionary<Type, object>();

            looper = new Looper();
            looper.loop();
        }

        public static Looper looper { get; private set; }
        public static IDbProvider DbProvider { get; set; }
        public static Dictionary<Type, object> Setters { get; set; }
    }
}
