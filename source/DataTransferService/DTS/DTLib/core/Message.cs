using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTLib.core
{
    public class Message
    {
        public Message()
        { 
            id = Guid.NewGuid();
            WorkMode = core.WorkMode.TaskScheduler;
        }
        public Message(string _msg, Action _handler = null)
            : base()
        {
            Msg = _msg;
            handler = _handler;
        }
        public Guid id { get; private set; }

        public string Msg { get; set; }
        public Action handler { get; set; }
        public WorkMode WorkMode { get; set; }
    }
}
