using System;
using System.Collections.Generic;

#nullable disable

namespace EFCOREEG.pubs
{
    public partial class Job
    {
        public Job()
        {
            Employees = new HashSet<Employees>();
        }

        public short JobId { get; set; }
        public string JobDesc { get; set; }
        public byte MinLvl { get; set; }
        public byte MaxLvl { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
