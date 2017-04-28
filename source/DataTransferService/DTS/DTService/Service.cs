using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using DTLib;
using DTLib.db;
using DTLib.log;
namespace DTService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    
    public class Service : IService
    {
        public void StartService()
        {
            DTEntry.Run();
        }

        public string GetData(string value)
        {
            return string.Format("You entered: {0}", value);
        }

        public void SetLogUri(string value)
        {
            byte[] outputb = Convert.FromBase64String(value);
            string orgStr = Encoding.Default.GetString(outputb);
            //@"E:\Work\yashanyang_view10\Casino\AH\Data\Log"
            DTEntry.looper.SendMsg(new DTLib.core.Message("set cfg path", () =>
            {
                if (!DTEntry.Setters.ContainsKey(typeof(CfgLogPathSetter)))
                {
                    CfgLogPathSetter cfgPathRegister = new CfgLogPathSetter();
                    cfgPathRegister.Set(orgStr);
                }
            }));
        }
        public void SetDBUri(string value)
        {
            //mongodb://192.168.15.113:27017@Events
            byte[] outputb = Convert.FromBase64String(value);
            string orgStr = Encoding.Default.GetString(outputb);
            DTEntry.looper.SendMsg(new DTLib.core.Message("set connection", () =>
            {
                if (!DTEntry.Setters.ContainsKey(typeof(CfgDbConnectionSetter)))
                {
                    CfgDbConnectionSetter cfgProvider = new CfgDbConnectionSetter();
                    cfgProvider.Set(orgStr);
                }
            }));
        }
    }
}
