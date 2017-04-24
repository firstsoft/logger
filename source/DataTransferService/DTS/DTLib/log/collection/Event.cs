using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Driver;
using MongoDB.Bson;
namespace DTLib.log.collection
{
    public class Event : Base
    {
        public ObjectId id { get; set; }
        public string machine { get; set; }
        public string eventType { get; set; }
        public string eventID { get; set; }
        public string eventGroup { get; set; }
        public string unitID { get; set; }
        public string slotID { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string message { get; set; }
        public DateTime datetime { get; set; }
    }
}
