using System;
using System.Collections.Generic;

#nullable disable

namespace EFCOREEG.pubs
{
    public partial class Employeesalary
    {
        public int TransactionNumber { get; set; }
        public int? EmployeeId { get; set; }
        public int? SalaryId { get; set; }
        public DateTime? SalDate { get; set; }

        public virtual Employeedetail Employee { get; set; }
        public virtual Salary Salary { get; set; }
    }
}
