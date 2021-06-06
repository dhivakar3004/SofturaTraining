using System.Collections.Generic;

namespace WebApplication2.Services
{
    public interface IRepo<T>
    {   IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T t);
        void Update(int id, T t);
        void Delete(T t);        
    }
}