using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson;
namespace DTLib.log.collection
{
    public class Task : Base
    {
        public ObjectId id { get; set; }
        public string machine { get; set; }
        public string taskId { get; set; }
        public string file { get; set; }
        public int status { get; set; }
        public int count { get; set; }
    }
}
