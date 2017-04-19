using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTLib.cfg
{
    public interface ICfgSetter<T>
    {
        void Set(Action<T> handler, T obj);
        void Set(T value);
        Action<T> Handler { get; }
        T Value { get; }
    }
}
