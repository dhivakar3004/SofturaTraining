using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSystem.Services
{
    public interface IPizza<T>
    {
        void Add(T t);
        void Delete(T t);
        void Update(int id, T t);
        IEnumerable<T> GetAll();
        T Get(int id);
    }
}