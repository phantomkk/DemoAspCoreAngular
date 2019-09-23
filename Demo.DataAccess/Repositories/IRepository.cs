using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.DataAccess.DataAccessObjects
{
    public interface IRepository<T>
    {
        T Create(T t);

        bool Update(T t);

        bool Delete(T t);

        IEnumerable<T> Filter(Func<T, bool> func);
    }
}
