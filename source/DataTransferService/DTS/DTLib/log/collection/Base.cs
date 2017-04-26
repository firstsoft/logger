using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTLib.log.collection
{
    public class Base
    {
        public bool deleted { get; set; }
        public DateTime createtime { get; set; }
        public string creator { get; set; }
        public DateTime modifietime { get; set; }
        public string revisor { get; set; }

        public Base()
        {
            this.deleted = false;
            this.createtime = DateTime.Now;
            this.modifietime = DateTime.Now;
        }
    }
}
