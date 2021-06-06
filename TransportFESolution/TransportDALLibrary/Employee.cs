using System;
using System.Collections.Generic;
using System.Text;

namespace TransportDALLibrary
{
   public  class Employee
    {
        public string Name{ get;  set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Location { get;  set; }
        public int Id { get;  set; }
        public string VehicleNumber { get; set; }

        public bool AddEmployee(Employee t)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Employee(EmployeeDAL v)
        {
            throw new NotImplementedException();
        }

       
    }
}
