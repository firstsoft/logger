using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTLib.db
{
    public interface IDbProvider
    {
        void Insert<T>(T obj,string table);
        void InsertMore<T>(List<T> objs, string table);

        void Update<T>(T obj, string table);


        void Connect(string connectionstring);
    }
}
