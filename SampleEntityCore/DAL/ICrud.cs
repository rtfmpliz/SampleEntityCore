using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleEntityCore.DAL
{
    public interface ICrud<T>
    {
        IEnumerable<T> GetAll();
        T GetById(string id);
        void Create(T obj);
        void Edit(string id, T obj);
        void Delete(string id);
    }
}
