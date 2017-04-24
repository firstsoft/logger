using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EventTranslaterLib;

using DTLib.log.collection;
namespace DTLib.log
{
    public class Actions
    {
        public static Action<string> Import = new Action<string>((t) =>
        {
            EventTranslaterLib.CLoggerMgrClass lm = new CLoggerMgrClass();
            lm.SetOfflineLanguage(0);

            lm.InitOfflineLoggerFolder((DTEntry.Setters[typeof(CfgLogPathSetter)] as CfgLogPathSetter).Value);
            int count;
            lm.LoadFile2(t, out count);
            Array data;
            lm.GetLogEvent(0, count, out data);
            GUI_LOGEVENT[] loggs = (GUI_LOGEVENT[])data;
            List<Event> events = new List<Event>();

            foreach(GUI_LOGEVENT log in loggs)
            {
                var dates = log.Date.Split('-');
                var times = log.Time.Split(':');
                events.Add(new Event()
                {
                    eventID =log.EventID,
                    eventType = log.EventType,
                    slotID = log.SlotID,
                    message = log.Description,
                    time =log.Time,
                    date = log.Date,
                    eventGroup = log.EventGroup,
                    unitID = log.UnitID,

                    datetime = new DateTime(int.Parse(dates[0]),int.Parse(dates[1]),int.Parse(dates[2]),
                        int.Parse(times[0]),int.Parse(times[1]),int.Parse(times[2]),int.Parse(times[3]))
                });
            }
            DTEntry.DbProvider.InsertMore<Event>(events,"Event");
        });
    }
}
