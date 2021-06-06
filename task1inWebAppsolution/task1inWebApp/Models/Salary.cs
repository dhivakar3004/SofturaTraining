using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace task1inWebApp.Models
{
    public class Salary
    {
        [Key]
        public int Salary_Id { get; set; }
        public int salary_ { get; set; }
        public string date { get; set; }
        public int Emp_Id { get; set; }

    }
}