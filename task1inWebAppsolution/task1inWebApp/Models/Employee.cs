using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace task1inWebApp.Models
{
    public class Employee
    {


        [Key]
        public int Emp_Id { get; set; }
        public string EmployeeName { get; set; }
        public int Age { get; set; }
        public string UserName { get; set; }

    }
}