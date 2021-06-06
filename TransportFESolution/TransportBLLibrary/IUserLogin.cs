using System;
using System.Collections.Generic;
using System.Text;
using TransportDALLibrary;

namespace TransportBLLibrary
{
    public interface IUserLogin<T>
    {
        bool Add(T t);
        bool Login(T t);
        bool Login(Employee employee);
     
    }
}
