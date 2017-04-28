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
            lock (objLock)
            {
                if (!isRunning)
                {
                    Setters = new Dictionary<Type, object>();
                    looper = new Looper();
                    looper.loop();
                    isRunning = true;
                }
            }
        }

        public static Looper looper { get; private set; }
        public static IDbProvider DbProvider { get; set; }
        public static Dictionary<Type, object> Setters { get; set; }
        private static bool isRunning = false;
        private static object objLock = new object();
    }
}
