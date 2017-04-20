using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DTLib.db
{
    public interface IDbProvider
    {
        void Insert<T>(T obj,string table);
        void InsertMore<T>(List<T> objs, string table);

        void Update<T>(T obj, string table);

        IEnumerable<T> Query<T>(string table);
        IEnumerable<T> Query<T>(string table, FilterDefinition<T> filter);

        void Connect(string connectionstring);
    }
}
