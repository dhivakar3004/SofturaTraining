using System;
using System.Collections.Generic;

#nullable disable

namespace EFCOREEG.pubs
{
    public partial class TblEmployee
    {
        public TblEmployee()
        {
            InverseManager = new HashSet<TblEmployee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public int? ManagerId { get; set; }

        public virtual TblEmployee Manager { get; set; }
        public virtual ICollection<TblEmployee> InverseManager { get; set; }
    }
}
