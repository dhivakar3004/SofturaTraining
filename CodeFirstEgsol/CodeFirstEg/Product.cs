using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeFirstEg
{
    public class Product
    {   [Key]
        public int pId { get; set; } 
        public string pName { get; set; }
        public int Price { get; set; }
        public int Qty { get; set; }

        public override string ToString()
        {
            return String.Format(pId + " " + pName + " " + Price + " " + Qty);
        }
    }
}
