using System;
using System.Collections.Generic;

#nullable disable

namespace EFCOREEG.pubs
{
    public partial class Employeedetail
    {
        public Employeedetail()
        {
            Employeesalaries = new HashSet<Employeesalary>();
        }

        public int Empid { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Employeesalary> Employeesalaries { get; set; }
    }
}
